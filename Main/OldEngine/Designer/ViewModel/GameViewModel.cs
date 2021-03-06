﻿using System;
using System.Runtime.CompilerServices;
using MudEngine.Engine.Core;
using Designer.Repositories;
using GalaSoft.MvvmLight;

namespace Designer.ViewModel
{
    /// <summary>
    /// The view model providing properties associated with the current IGame and its dependencies.
    /// </summary>
    public class GameViewModel : ViewModelBase
    {
        /// <summary>
        /// The game
        /// </summary>
        private readonly IGame game;

        /// <summary>
        /// The IsDirty backing variable
        /// </summary>
        private bool isDirty;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameViewModel"/> class.
        /// </summary>
        public GameViewModel()
        {
            if (IsInDesignMode)
            {
            }
            else
            {
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is dirty.
        /// </summary>
        public bool IsDirty
        {
            get
            {
                return this.isDirty;
            }
            set
            {
                this.isDirty = value;
                this.RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the name of the game.
        /// </summary>
        public string Name
        {
            get
            {
                return this.game.Name;
            }
            set
            {
                this.game.Name = value;
                this.RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the version for this game.
        /// </summary>
        public Version Version
        {
            get
            {
                return this.game.Version;
            }
            set
            {
                this.game.Version = value;
                this.RaisePropertyChanged();
            }
        }

        protected override void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            base.RaisePropertyChanged(propertyName);
        }
    }
}
