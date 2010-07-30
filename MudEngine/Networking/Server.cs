﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

using MudEngine.GameObjects.Characters;
using MudEngine.GameManagement;

/* Usage:
 *  Server MUDServer = new Server();
 *  MUDServer.InitializeUDP(666); or MUDServer.InitializeTCP(666);
 *  MUDServer.Start();
 */

namespace MudEngine.Networking
{
    public class Server
    {
        public Server()
        {
            stage = 0;
            port = 0;
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }
        ~Server()
        {
            stage = 0;
            port = 0;
        }
        public bool Initialize(int p, ref /*List<BaseCharacter>*/BaseCharacter[] pbs)
        {
            if (stage != 0)
                return false;
            if (p <= 0)
                return false;
            port = p;
            players = pbs;
            clientThreads = new Thread[players.Length];
            stage++;
            return true;
        }
        public bool Start()
        {
            try
            {
                if (stage != 1)
                    return false;
                IPEndPoint ipep = new IPEndPoint(IPAddress.Any, port);
                server.Bind(ipep);
                server.Listen(10);
                stage++;
                serverThread = new Thread(ServerThread);
                serverThread.Start();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public void EndServer()
        {
            stage = 0;
            serverThread.Abort();
            server.Close();
        }
        private void ServerThread()
        {
            while (stage == 2)
            {
                int sub = -1;
                do
                {
                    for (int i = 0; i < players./*Count*/Length; i++)
                    {
                        if (!players[i].IsActive)
                        {
                            sub = i;
                            break;
                        }
                    }
                } while (sub < 0);
                players[sub].client = server.Accept();
                players[sub].Initialize();
                Log.Write("New Player Connected.");
                //ParameterizedThreadStart start = new ParameterizedThreadStart(ReceiveThread);
                clientThreads[sub] = new Thread(ReceiveThread);
                clientThreads[sub].Start((object)sub);
            }
        }
        private void ReceiveThread(object obj)
        {
            int sub = (int)obj;
            List<byte> buffer = new List<byte>();
            while (stage == 2 && players[sub].IsActive)
            {
                try
                {
                    byte[] buf = new byte[1];
                    int recved = players[sub].client.Receive(buf);
                    
                    if (recved > 0)
                    {
                        if (buf[0] == '\n' && buffer.Count > 0)
                        {
                            if (buffer[buffer.Count-1] == '\r')
                                buffer.RemoveAt(buffer.Count-1);
                            players[sub].Receive(buffer.ToArray());
                            buffer.Clear();
                        }
                        else
                            buffer.Add(buf[0]);
                    }
                }
                catch (Exception) // error receiving, close player
                {
                    this.Disconnect(sub);
                }
            }
        }
        public void Disconnect(int sub)
        {
            if (sub > 0 && sub < players./*Capacity*/Length)
            {
                clientThreads[sub].Abort();
                if(players[sub].IsActive)
                    players[sub].Disconnect();
            }
        }

        private Thread serverThread;
        private Socket server;
        private int stage;
        private int port;

        //List<BaseCharacter> players;
        BaseCharacter[] players;

        // TCP Stuff:
        private Thread[] clientThreads;
    }
}