﻿//-----------------------------------------------------------------------
// <copyright file="IMob.cs" company="AllocateThis!">
//     Copyright (c) AllocateThis! Studio's. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
using System;
using MudEngine.Engine.Core;
using MudEngine.Engine.GameObjects.Environment;

namespace MudEngine.Engine.GameObjects.Mob
{
    /// <summary>
    /// Provides a contract for objects that need to be a Mob.
    /// </summary>
    public interface IMob : IGameObject
    {
        /// <summary>
        /// Gets or Sets the currently running game.
        /// </summary>
        IGame Game { get; set; }

        /// <summary>
        /// Gets or sets the gender for this character.
        /// </summary>
        IGender Gender { get; set; }

        /// <summary>
        /// Gets or sets this characters current location in the world.
        /// </summary>
        IRoom Location { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance can speak or not..
        /// </summary>
        bool IsMute { get; set; }

        /// <summary>
        /// Gets or sets the maximum size of the inventory.
        /// </summary>
        /// <value>
        /// The maximum size of the inventory.
        /// </value>
        int MaximumInventorySize { get; set; }

        event EventHandler<MovementEventArgs> Move;

        event EventHandler<IMessage> SendMessage;

        event EventHandler<IMessage> ReceivedMessage;

        void ReceiveInput(IMessage message);

        void Send(IMessage message);
    }
}
