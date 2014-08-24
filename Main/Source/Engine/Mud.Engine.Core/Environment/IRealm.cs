﻿//-----------------------------------------------------------------------
// <copyright file="IRealm.cs" company="Sully">
//     Copyright (c) Johnathon Sullinger. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Mud.Engine.Core.Environment
{
    using System.Collections.Generic;

    /// <summary>
    /// IRealm can be implemented to provide Realm support to an object.
    /// </summary>
    public interface IRealm : IEnvironment
    {
        /// <summary>
        /// Gets or sets the offset from the World's current time for the Realm in hours.
        /// </summary>
        /// <value>
        /// The time zone offset.
        /// </value>
        double TimeZoneOffset { get; set; }

        /// <summary>
        /// Gets or sets the time of day for the Realm.
        /// </summary>
        /// <value>
        /// The time of day.
        /// </value>
        ITimeOfDayState TimeOfDay { get; set; }

        /// <summary>
        /// Gets or sets the current weather.
        /// </summary>
        /// <value>
        /// The current weather.
        /// </value>
        IWeatherState CurrentWeather { get; set; }

        /// <summary>
        /// Gets or sets a collection of states that can be used to determine the current weather.
        /// </summary>
        /// <value>
        /// The weather states.
        /// </value>
        IEnumerable<IWeatherState> WeatherStates { get; set; }

        /// <summary>
        /// Gets or sets the zones within this Realm.
        /// </summary>
        /// <value>
        /// The zones.
        /// </value>
        IEnumerable<IZone> Zones { get; set; }
    }
}