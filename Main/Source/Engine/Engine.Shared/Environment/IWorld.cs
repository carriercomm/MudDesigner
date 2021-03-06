﻿//-----------------------------------------------------------------------
// <copyright file="IWorld.cs" company="Sully">
//     Copyright (c) Johnathon Sullinger. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Mud.Engine.Shared.Environment
{
    using System;
    using System.Collections.Generic;
    using Mud.Engine.Shared.Environment;

    /// <summary>
    /// Defines a world 
    /// </summary>
    public interface IWorld : IEnvironment, IDisposable
    {
        /// <summary>
        /// Occurs when the worlds time of day has changed.
        /// </summary>
        event EventHandler<TimeOfDayChangedEventArgs> TimeOfDayChanged;

        /// <summary>
        /// Gets or sets the current time of day.
        /// </summary>
        /// <value>
        /// The current time of day.
        /// </value>
        ITimeOfDayState CurrentTimeOfDay { get; set; }

        /// <summary>
        /// Gets or sets a collection of states that can be used for the time of day.
        /// </summary>
        /// <value>
        /// The time of day states.
        /// </value>
        IEnumerable<ITimeOfDayState> TimeOfDayStates { get; set; }

        /// <summary>
        /// Gets or sets how many hours it takes in-game to complete 1 day for this world.
        /// </summary>
        /// <value>
        /// The hours per day.
        /// </value>
        int HoursPerDay { get; set; }

        /// <summary>
        /// Gets or sets the hours factor. If set to 4, it takes 4 in-game hours to equal 1 real-world hour.
        /// </summary>
        /// <value>
        /// The hours ratio.
        /// </value>
        double GameDayToRealHourRatio { get; set; }

        /// <summary>
        /// Gets the game time ratio used to convert real-world time to game-time.
        /// </summary>
        /// <value>
        /// The game time ratio.
        /// </value>
        double GameTimeAdjustmentFactor { get; }

        /// <summary>
        /// Gets or sets the realms in this world.
        /// </summary>
        /// <value>
        /// The realms.
        /// </value>
        IEnumerable<IRealm> Realms { get; set; }

        /// <summary>
        /// Gets the number of realms.
        /// </summary>
        int NumberOfRealms { get; }

        /// <summary>
        /// Initializes this instance. The environment time and states are set up.
        /// </summary>
        /// <param name="initialState">The initial state.</param>
        void Initialize(ITimeOfDayState initialState = null);

        /// <summary>
        /// Adds the given realm to world and initializes it.
        /// </summary>
        /// <param name="realm">The realm.</param>
        void AddRealmToWorld(IRealm realm);

        /// <summary>
        /// Adds a collection of realms to world.
        /// </summary>
        /// <param name="realm">The realm.</param>
        void AddRealmToWorld(IEnumerable<IRealm> realm);

        /// <summary>
        /// Removes the realm from world.
        /// </summary>
        /// <param name="realm">The realm.</param>
        void RemoveRealmFromWorld(IRealm realm);

        /// <summary>
        /// Adds the time of day state to the world.
        /// </summary>
        /// <param name="state">The state.</param>
        void AddTimeOfDayState(ITimeOfDayState state);
    }
}
