﻿//-----------------------------------------------------------------------
// <copyright file="IWeatherState.cs" company="Sully">
//     Copyright (c) Johnathon Sullinger. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Mud.Engine.Core.Environment
{
    /// <summary>
    /// Defines a state that weather can be in.
    /// </summary>
    public interface IWeatherState
    {
        /// <summary>
        /// Gets or sets the occurrence probability of this weather state occurring in an environment.
        /// The higher the probability relative to other weather states, the more likely it is going to occur.
        /// </summary>
        /// <value>
        /// The occurrence probability.
        /// </value>
        double OccurrenceProbability { get; }

        string Name { get; }
    }
}
