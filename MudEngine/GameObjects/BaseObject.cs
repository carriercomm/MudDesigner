﻿//Microsoft .NET Framework
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Xml.Serialization;
using System.IO;

//MUD Engine
using MudEngine.FileSystem;
using MudEngine.GameManagement;

namespace MudEngine.GameObjects
{
    public class BaseObject
    {
        [Category("Object Setup")]
        [Description("The Display Name assigned to this object.")]
        //Required to refresh Filename property in the editors propertygrid
        [RefreshProperties(RefreshProperties.All)]
        public string Name
        {
            get
            {
                return this._Name;
            }
            set
            {
                this._Name = value;
                this.Filename = value + "." + this.GetType().Name;
            }
        }

        [Category("Object Setup")]
        [Description("A brief description of this object. The description is displayed to users when they use a command for investigating an object")]
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// A detailed description that treats each entry as a seperete line when outputted to the player
        /// </summary>
        public List<string> DetailedDescription { get; set; }

        [Category("Object Setup")]
        [Description("The object script that can manipulate the object during the games life.")]
        //[EditorAttribute(typeof(UIScriptEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string Script { get; set; }

        [Category("Object Setup")]
        [ReadOnly(true)]
        [Description("The filename of the current object. This is assigned by the engine and not editable.")]
        public string Filename
        {
            //Returns the name of the object + the objects Type as it's extension.
            //Filenames are generated by the class itself, users can not assign it.
            get
            {
                return this._Filename;
            }
            set
            {
                string extension = "." + this.GetType().Name;
                if (!value.EndsWith(extension))
                    value += extension;

                this._Filename = value;
            }
        }

        [Category("Environment Information")]
        [Description("If a user asks to use his/her senses to investigate an area, this is one of the results that will be displayed. Senses can be used to assist blind characters.")]
        [DefaultValue("You don't smell anything unsual.")]
        public string Smell
        {
            get;
            set;
        }

        [Category("Environment Information")]
        [Description("If a user asks to use his/her senses to investigate an area, this is one of the results that will be displayed. Senses can be used to assist blind characters.")]
        [DefaultValue("You hear nothing of interest.")]
        public string Listen
        {
            get;
            set;
        }

        [Category("Environment Information")]
        [Description("If a user asks to use his/her senses to investigate an area, this is one of the results that will be displayed. Senses can be used to assist blind characters.")]
        [DefaultValue("You feel nothing.")]
        public string Feel
        {
            get;
            set;
        }

        private string _Filename = "";
        private string _Name = "";
        internal Game ActiveGame { get; set; }

        /// <summary>
        /// Initializes the base object
        /// </summary>
        public BaseObject(Game game)
        {
            Script = "";
            _Name = "New " + this.GetType().Name;
            _Filename = _Name + "." + this.GetType().Name;
            ActiveGame = game;

            this.Feel = "You feel nothing.";
            this.Listen = "You hear nothing of interest.";
            this.Smell = "You don't smell anything unsual.";
            this.Name = DefaultName();
        }

        private bool ShouldSerializeName()
        {
            return this.Name != DefaultName();
        }

        private void ResetName()
        {
            this.Name = DefaultName();
        }

        private string DefaultName()
        {
            return "New " + this.GetType().Name;
        }

        #region Public Methods
        /// <summary>
        /// Loads the supplied filename and returns it.
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public virtual object Load(string filename)
        {
            if (!File.Exists(filename))
            {
                return null;
            }

            return FileManager.Load(filename, this);
        }

        /// <summary>
        /// Saves the current object with the supplied filename
        /// </summary>
        /// <param name="filename"></param>
        public void Save(string filename)
        {
            string directory = Path.GetDirectoryName(filename);
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);
            FileManager.Save(filename, this);
        }

        public override string ToString()
        {
            return this.Name;
        }

        public virtual void OnEnter()
        {
        }

        public virtual void OnExit()
        {
        }

        public virtual void OnCreate()
        {
        }

        public virtual void OnDestroy()
        {
        }

        public virtual void OnEquip()
        {
        }

        public virtual void OnUnequip()
        {
        }

        public virtual void OnMount()
        {
        }

        public virtual void OnDismount()
        {
        }
        #endregion
    }
}
