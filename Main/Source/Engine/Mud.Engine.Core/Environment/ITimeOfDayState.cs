﻿//-----------------------------------------------------------------------
// <copyright file="ITimeOfDayState.cs" company="Sully">
//     Copyright (c) Johnathon Sullinger. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
using System;
namespace Mud.Engine.Core.Environment
{
    /// <summary>
    /// Allows a specific time of day to be given a state.
    /// </summary>
    public interface ITimeOfDayState
    {
        /// <summary>
        /// Occurs when the state's time is changed.
        /// </summary>
        event EventHandler<TimeOfDay> TimeUpdated;

        /// <summary>
        /// Gets the name of this state.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        string Name { get; }

        /// <summary>
        /// Gets the current time.
        /// </summary>
        /// <value>
        /// The current time.
        /// </value>
        TimeOfDay CurrentTime { get; }

        /// <summary>
        /// Gets the time of day in the game that this state begins in hours.
        /// </summary>
        /// <value>
        /// The state start time.
        /// </value>
        TimeOfDay StateStartTime { get; set; }

        /// <summary>
        /// Initializes the time of day state with the supplied in-game to real-world hours factor.
        /// </summary>
        /// <param name="worldTimeFactor">The world time factor.</param>
        /// <param name="hoursPerDay">The hours per day.</param>
        void Initialize(double worldTimeFactor, int hoursPerDay);

        /// <summary>
        /// Resets this instance current time to that if its start time.
        /// </summary>
        void Reset();

        // TODO: Need to add events for when we transition out of a ITimeOfDayState.
    }
}
