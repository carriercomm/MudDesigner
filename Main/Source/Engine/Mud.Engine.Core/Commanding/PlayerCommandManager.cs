﻿using Mud.Engine.Core.Character;
using Mud.Engine.Core.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mud.Engine.Core.Commanding
{
    public class PlayerCommandManager : ICommandManager
    {
        private List<ICommand> commands = new List<ICommand>();

        private Queue<ICommand> CommandQueue = new Queue<ICommand>();

        private IPlayer player;

        private List<string> History = new List<string>();

        public async Task Initialize(ICharacter character)
        {
            if (!(character is IPlayer))
            {
                throw new InvalidCastException("The PlayerCommandManager can only be used on a Type that implements IPlayer.");
            }

            this.player = character as IPlayer;
            if (this.commands.Count > 0)
            {
                this.commands.Clear();
            }

            this.commands.AddRange(this.player.Permission.AvailableCommands);
        }

        public async Task HandleMessage(IMessage message)
        {
            await this.HandleMessages(message);
        }

        public async Task HandleMessages(IMessage message)
        {
            await Task.Run(() => this.player.CurrentRoom.Occupants.AsParallel().ForAll(occupant =>
            {
                if (!(occupant is INPCCharacter))
                {
                    return;
                }

                occupant.AcceptMessage(message);
            }));
        }

        public string[] GetCommandHistory()
        {
            throw new NotImplementedException();
        }
    }
}