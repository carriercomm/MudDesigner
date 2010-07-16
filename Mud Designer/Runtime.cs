﻿//Microsoft .NET Framework
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//MUD Designer
using MudEngine.Commands;
using MudEngine.FileSystem;
using MudEngine.GameManagement;
using MudEngine.GameObjects;
using MudEngine.GameObjects.Characters;
using MudEngine.GameObjects.Characters.Controlled;
//using MudEngine.GameObjects.Characters.NPC;
using MudEngine.GameObjects.Environment;
using MudEngine.GameObjects.Items;

namespace MudDesigner
{
    public partial class Runtime : Form
    {
        PlayerBasic _Player;
        Room _Room;
        GameSetup _Project;

        public Runtime()
        {
            InitializeComponent();
            _Player = new PlayerBasic();
            _Project = new GameSetup();
            _Room = new Room();
        }

        public void ExecuteCommand(string command)
        {
            CommandResults result = CommandEngine.ExecuteCommand(command, _Player, _Project, _Room, command);

            if (result.Result == null)
                return;

            foreach (object obj in result.Result)
            {
                switch (obj.GetType().Name.ToLower())
                {
                    case "string":
                        Print(obj.ToString());
                        break;
                    case "room":
                        _Room = (Room)obj;
                        break;
                    case "projectinformation":
                        _Project = (GameSetup)obj;
                        break;
                    case "playerbasic":
                        _Player = (PlayerBasic)obj;
                        break;
                }
            }

            txtCommand.Clear();
        }
        public void Print(string message)
        {
            if (string.IsNullOrEmpty(message))
                return;

            txtConsole.Text += message + "\n";
            txtConsole.Select(txtConsole.Text.Length - 1, 0);
        }

        public void Print(bool newLine)
        {
            txtCommand.Text += "\n";
            txtConsole.Select(txtConsole.Text.Length - 1, 0);
        }

        private void Runtime_Load(object sender, EventArgs e)
        {
            Print("Loading project information...");
            if (!File.Exists(FileManager.GetDataPath(SaveDataTypes.Root) + "\\Game.xml"))
            {
                Print("Failed Loading Project Information... Runtime failed to initialize.");
                return;
            }
            _Project = (GameSetup)_Project.Load(FileManager.GetDataPath(SaveDataTypes.Root));
            if (_Project.InitialLocation.Zone == null && _Project.InitialLocation.Zone == "")
            {
                Print("No Initial Zone was defined within the Project Information. Please associated a Zone to the Projects Initial Zone setting in order to launch the game.");
                return;
            }

            Print("Loading environment...");

            _Room = (Room)_Room.Load(_Project.InitialLocation.Room, _Project.InitialLocation.Zone);

            Print("Prepping test player...");
            _Player.CurrentRoom = _Room;

            Print("Loading Game Commands...");
            CommandEngine.LoadAllCommands();

            Print("Startup Complete.");
            Print(true); //blank line
            txtCommand.Select();

            if (string.IsNullOrEmpty(_Project.CompanyName))
                Print("No company name defined for the project!");
            else
                Print("Created by " + _Project.CompanyName);

            if (string.IsNullOrEmpty(_Project.Website))
                Print("No website defined for the project!");
            else
                Print("Visit us at " + _Project.Website);

            if (string.IsNullOrEmpty(_Project.GameTitle))
                Print("No Game Title defiend for the project!");
            else
                Print(_Project.GameTitle);

            if (string.IsNullOrEmpty(_Project.Version))
                Print("Game Version was not specified.");
            else
                Print(_Project.Version);

            if (string.IsNullOrEmpty(_Project.Story))
                Print("The games startup story has not been created yet!");
            else
                Print(_Project.Story);

            Print(true);//blank line
            ExecuteCommand("Look");
        }

        private void txtCommand_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ExecuteCommand(txtCommand.Text);
            }
        }

        private void btnNorth_Click(object sender, EventArgs e)
        {
            ExecuteCommand("Walk North");
        }

        private void btnSouth_Click(object sender, EventArgs e)
        {
            ExecuteCommand("Walk South");
        }

        private void btnWest_Click(object sender, EventArgs e)
        {
            ExecuteCommand("Walk West");
        }

        private void btnEast_Click(object sender, EventArgs e)
        {
            ExecuteCommand("Walk East");
        }

        private void btnLook_Click(object sender, EventArgs e)
        {
            ExecuteCommand("Look");
        }
    }
}
