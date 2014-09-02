﻿//-----------------------------------------------------------------------
// <copyright file="DefaultPlayer.cs" company="Sully">
//     Copyright (c) Johnathon Sullinger. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Mud.Engine.Core.Character
{
    using System;
    using Mud.Engine.Core.Engine;
    using Mud.Engine.Core.Environment;

    /// <summary>
    /// The Default Engine implementation of IPlayer.
    /// </summary>
    public class DefaultPlayer : IPlayer
    {
        /// <summary>
        /// The CurrentRoom property backing field.
        /// </summary>
        private IRoom currentRoom;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultPlayer"/> class.
        /// </summary>
        public DefaultPlayer()
        {
            this.Id = Guid.NewGuid();
        }

        /// <summary>
        /// Occurs when the object is loaded.
        /// </summary>
        public event EventHandler Loaded;

        /// <summary>
        /// Occurs when being unloaded.
        /// </summary>
        public event EventHandler Unloaded;

        /// <summary>
        /// Occurs when the instance receives an IMessage.
        /// </summary>
        public event EventHandler<InputArgs> MessageReceived;

        /// <summary>
        /// Occurs when the instance sends an IMessage.
        /// </summary>
        public event EventHandler<InputArgs> MessageSent;

        /// <summary>
        /// Occurs when the character changes rooms.
        /// </summary>
        public event EventHandler<OccupancyChangedEventArgs> RoomChanged;

        /// <summary>
        /// Gets or sets the unique identifier.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets the game.
        /// </summary>
        public IGame Game { get; private set; }

        /// <summary>
        /// Gets or sets the current room that this character occupies.
        /// </summary>
        public IRoom CurrentRoom
        {
            get
            {
                return this.currentRoom;
            }

            set
            {
                IRoom departingRoom = this.currentRoom;
                this.currentRoom = value;

                this.OnRoomChanged(departingRoom, value);
            }
        }

        /// <summary>
        /// Initializes this instance with the given game.
        /// </summary>
        /// <param name="game">The game.</param>
        public void Initialize(IGame game)
        {
            this.Game = game;
            this.OnLoaded();
        }

        /// <summary>
        /// Sends the message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void SendMessage(string message)
        {
            this.OnMessageSent(message);
        }

        /// <summary>
        /// Called when the player is loaded.
        /// </summary>
        protected virtual void OnLoaded()
        {
            EventHandler handler = this.Loaded;
            if (handler == null)
            {
                return;
            }

            handler(this, new EventArgs());
        }

        /// <summary>
        /// Called when the player is unloaded.
        /// </summary>
        protected virtual void OnUnloaded()
        {
            EventHandler handler = this.Unloaded;
            if (handler == null)
            {
                return;
            }

            handler(this, new EventArgs());
        }

        /// <summary>
        /// Called when an IMessage is received.
        /// </summary>
        /// <param name="message">The message.</param>
        protected virtual void OnMessageReceived(string message)
        {
            EventHandler<InputArgs> handler = this.MessageReceived;
            if (handler == null)
            {
                return;
            }

            handler(this, new InputArgs(message));
        }

        /// <summary>
        /// Called when an IMessage is sent from the player.
        /// </summary>
        /// <param name="message">The message.</param>
        protected virtual void OnMessageSent(string message)
        {
            EventHandler<InputArgs> handler = this.MessageSent;
            if (handler == null)
            {
                return;
            }

            handler(this, new InputArgs(message));
        }

        /// <summary>
        /// Called when the character changes rooms.
        /// </summary>
        /// <param name="departingRoom">The departing room.</param>
        /// <param name="arrivalRoom">The arrival room.</param>
        protected virtual void OnRoomChanged(IRoom departingRoom, IRoom arrivalRoom)
        {
            EventHandler<OccupancyChangedEventArgs> handler = this.RoomChanged;
            if (handler == null)
            {
                return;
            }

            handler(this, new OccupancyChangedEventArgs(this, departingRoom, arrivalRoom));
        }
    }
}