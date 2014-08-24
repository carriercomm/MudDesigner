﻿//-----------------------------------------------------------------------
// <copyright file="DesktopGame.cs" company="Sully">
//     Copyright (c) Johnathon Sullinger. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Mud.Engine.Default.Desktop.Engine
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Mud.Engine.Core.Engine;
    using Mud.Engine.Core.Environment;
    using Mud.Repositories.Shared;

    /// <summary>
    /// The default implementation of the IGame interface for the Mud Engine.
    /// </summary>
    public class DesktopGame : DefaultGame
    {
        /// <summary>
        /// The world repository
        /// </summary>
        private IWorldRepository worldRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="DesktopGame"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="worldRepository">The world repository.</param>
        public DesktopGame(IWorldRepository worldRepository) 
            : base(null)
        {
            this.worldRepository = worldRepository;
        }

        /// <summary>
        /// The initialize method is responsible for restoring the world and state.
        /// </summary>
        /// <returns>
        /// Returns the Task associated with the await call.
        /// </returns>
        /// <exception cref="System.NullReferenceException">Unable to restore the world due to a null IWorldRepository object.</exception>
        public async override Task Initialize()
        {            
            if (this.worldRepository == null)
            {
                throw new NullReferenceException("Unable to restore the world due to a null IWorldRepository object.");
            }

            // Restore our previously saved worlds.
            IEnumerable<IWorld> result = await this.worldRepository.GetAllWorlds(true);

            this.Worlds = new List<IWorld>(result);

            var world = new DefaultWorld();
            world.Initialize();

            this.Worlds.Add(world);
        }
    }
}