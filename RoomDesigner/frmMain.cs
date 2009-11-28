﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using MUDEngine.Objects.Environment;
using MUDEngine.Objects;
using MUDEngine;
using MUDEngine.FileSystem;
using MUDEngine.Attributes;

namespace RoomDesigner
{
    public partial class frmMain : Form
    {
        //Current _CurrentRoom
        Room _CurrentRoom;

        //Doorway currently loaded.
        Door _CurrentDoor;

        //Scripting engine and it's components.
        ManagedScripting.ScriptingEngine _ScriptEngine;
        
        //Collection of plugins from within the 'plugins' folder
        List<System.Reflection.Assembly> _Plugins;

        public frmMain(params object[] parameters)
        {
            InitializeComponent();
            SetupEditor(parameters);
        }

        private void SetupEditor(params object[] parameters)
        {
            //Initialize the Room & Doorway
            _CurrentRoom = new Room();
            _CurrentDoor = new Door(AvailableTravelDirections.None);

            //This instances a copy of AvailableTravelDirections which is a list of
            //currently available directions users can travel within rooms.
            //Instead of updating the editor each time a new travel direction is implemented,
            //we simply build an array that contains each travel direction currently available
            //within the engine by getting each element from the AvailableTravelDirections enum
            BuildDoorwayList();

            //Load all of our plugin .dll files. This is the only directory not generated by
            //the engine, developers will need to manually create the folder if they want to
            //create plugins
            LoadPlugins();

            //Instance the scripting engine and set it up.
            _ScriptEngine = new ManagedScripting.ScriptingEngine();
            _ScriptEngine.Compiler = ManagedScripting.ScriptingEngine.CompilerSelections.SourceCompiler;
            _ScriptEngine.CompileStyle = ManagedScripting.Compilers.BaseCompiler.ScriptCompileStyle.CompileToMemory;
            _ScriptEngine.KeepTempFiles = false;

            //Get the current rooms scripts.
            //TODO: Add Doorway script support
            SetupRoomScript();

            if (parameters.Length != 0)
            {
                foreach (object argument in parameters)
                {
                    if (argument.ToString().ToLower().StartsWith("room="))
                    {
                        string rooms = Engine.GetDataPath(Engine.SaveDataTypes.Rooms);
                        string filename = System.IO.Path.Combine(rooms, argument.ToString());

                        //Room to load should always be the first arg.
                        if (System.IO.File.Exists(filename))
                        {
                            _CurrentRoom = (Room)ManagedScripting.XmlSerialization.Load(filename, _CurrentRoom);
                        }
                    }
                }
            }


            //Show the user(s) the rooms properties
            propertyRoom.SelectedObject = _CurrentRoom;
        }

        private void SetupRoomScript()
        {
            //Check if the rooms script is empty. If so then generate a standard script for it.
            if (String.IsNullOrEmpty(_CurrentRoom.Script))
            {
                //Instance a new method helper class
                ManagedScripting.CodeBuilding.MethodSetup method = new ManagedScripting.CodeBuilding.MethodSetup();
                string script = "";
                //Setup our method. All objects inheriting from BaseObject will have the standard
                //methods created for them.
                string[] names = new string[] { "OnCreate", "OnDestroy", "OnEnter", "OnExit" };
                foreach (string name in names)
                {
                    method = new ManagedScripting.CodeBuilding.MethodSetup();
                    method.Name = name;
                    method.ReturnType = "void";
                    method.IsOverride = true;
                    method.Modifier = ManagedScripting.CodeBuilding.ClassGenerator.Modifiers.Public;
                    method.Code = new string[] { "base." + method.Name + "();" };
                    script = script.Insert(_CurrentRoom.Script.Length, method.Create() + "\n");
                }
                _CurrentRoom.Script = script;
            }
        }

        private void BuildDoorwayList()
        {
            AvailableTravelDirections direction = new AvailableTravelDirections();

            //Build an array of travel directions currently implemented
            Array Values = System.Enum.GetValues(direction.GetType());

            //Loop through each travel direction within the array and add it
            //to the lstDirections listbox.
            foreach (int Value in Values)
            {
                string Display = Enum.GetName(direction.GetType(), Value);
                //The array contains a 'None' direction. As the editor will allow for
                //installing and uninstalling doorways, we don't need to show a 'None' direction
                //in the listbox.
                if (!Display.Equals("None"))
                    this.lstDirections.Items.Add(Display);
            }
        }

        private void LoadPlugins()
        {
            string pluginPath = System.IO.Path.Combine(Application.StartupPath, "Plugins");
            _Plugins = new List<System.Reflection.Assembly>();
            
            //Check if the plugin path exists.
            if (!System.IO.Directory.Exists(pluginPath))
                return;

            //Now loop through every .dll file in the plugins directory and load it into memory
            //A copy is stored within a collection for use later if needed.
            foreach (string assembly in System.IO.Directory.GetFiles(pluginPath, "*.dll"))
            {
                _Plugins.Add(System.Reflection.Assembly.LoadFile(assembly));
            }

            //TODO: Look for ways to allow Types to inherit from a Windows Control, and add each
            //control to a new tab or menu item, allowing for editor plugins as well.
        }

        /// <summary>
        /// Closes the editor.
        /// TODO: Serialize the Room out to file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCloseEditor_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Change the currently selected direction, allowing users to uninstall or install
        /// a doorway, and display the selected doorways properties for editing.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstDirections_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Used to indicate that the direction the user selected exists,
            //and was found for editing
            bool IsFound = false;

            //Loop through each doorway installed within the _CurrentRoom and see if the user has
            //selected a direction that belongs to a _CurrentDoor already created. If a _CurrentDoor with 
            //the selected direction is found, we display it's properties for editing instead
            //of creating a new _CurrentDoor and overwriting the previously created doorway.
            foreach (Door newDoor in _CurrentRoom.InstalledDoors)
            {
                //Check if the current _CurrentDoor in the loop matches the currently selected
                //travel direction the user has selected in the listbox.
                if (newDoor.TravelDirection.ToString() == lstDirections.SelectedItem.ToString())
                {
                    //The travel directions match, let's set the current _CurrentDoor in the loop as our
                    //new selected doorway so that the user can edit it. 
                    _CurrentDoor = newDoor;

                    //Indicates that we found a matching doorway and have set it up for
                    //editing within the propertygrid
                    IsFound = true;

                    //Exit the loop
                    break;
                }
            }

            //There isn't a _CurrentDoor installed into the _CurrentRoom yet with a travel direction
            //matching that of the users currently selected travel direction within the listbox.
            //so we instance a new _CurrentDoor
            if (!IsFound)
            {
                AvailableTravelDirections direction = GetDirection(lstDirections.SelectedItem.ToString());
                _CurrentDoor = new Door(direction);
            }
            //Display the properties for users to edit. This could be a pre-existing doorway
            //found within our loop, or a new doorway.
            propertyDoor.SelectedObject = _CurrentDoor;
        }

        /// <summary>
        /// Modified values within the doorway get stored within the currentDoor Field.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="e"></param>
        private void propertyDoor_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            //Check if we are installing the door into the room or
            //uninstalling it from the current room.
            switch (_CurrentDoor.DoorState)
            {
                case Door.AvailableDoorStates.Installed:
                    InstallDoor();
                    break;
                case Door.AvailableDoorStates.Uninstalled:
                    UninstallDoor();
                    break;
            }
        }

        /// <summary>
        /// Converts a string into an AvailableTravelDirections enum equivilant if it
        /// exists within the enum list.
        /// </summary>
        /// <param name="Direction"></param>
        /// <returns></returns>
        private AvailableTravelDirections GetDirection(string Direction)
        {
            foreach (AvailableTravelDirections value in Enum.GetValues(typeof(AvailableTravelDirections)))
            {
                string name = value.ToString();

                if (name == Direction)
                    return value;
            }

            return AvailableTravelDirections.None;
        }

        /// <summary>
        /// Installs the _CurrentDoor into the _CurrentRoom's collection of doorways
        /// </summary>
        private void InstallDoor()
        {
            //Indicates if we found a door already installed within the room
            //matching the selected travel direction.
            bool IsInstalled = false;

            //Incase there are no existing doors, the foreach loop gets skipped.
            if (_CurrentRoom.InstalledDoors.Count == 0)
            {
                //Add the new door to the room
                _CurrentRoom.InstalledDoors.Add(_CurrentDoor);
                return;
            }

            //Loop through all of the installed doors within this room and
            //check to see if we have a doorway with the same travel direction
            //that the user has selected within the list box. If so then we
            //need to prompt the user to ensure it's ok to overwrite the previous
            //door with a new door.
            foreach (Door newDoor in _CurrentRoom.InstalledDoors)
            {
                if (newDoor.TravelDirection == _CurrentDoor.TravelDirection)
                {
                    _CurrentRoom.InstalledDoors.Remove(newDoor);
                    _CurrentRoom.InstalledDoors.Add(_CurrentDoor);
                    IsInstalled = true;
                    break;
                }
            }

            if (!IsInstalled)
                _CurrentRoom.InstalledDoors.Add(_CurrentDoor);
        }

        /// <summary>
        /// Uninstalls the doorway from the room.
        /// </summary>
        private void UninstallDoor()
        {
            foreach (Door door in _CurrentRoom.InstalledDoors)
            {
                if (door.TravelDirection == _CurrentDoor.TravelDirection)
                {
                    _CurrentRoom.InstalledDoors.Remove(door);
                    break;
                }
            }
        }

        /// <summary>
        /// Resets the room.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewRoom_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to create a new room?", "Room Designer", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
                return;

            _CurrentRoom = new Room();
            _CurrentDoor = new Door(AvailableTravelDirections.None);
            
            propertyDoor.SelectedObject = null;
            propertyRoom.SelectedObject = _CurrentRoom;
        }

        private void btnSaveRoom_Click(object sender, EventArgs e)
        {
            string savePath = Engine.GetDataPath(Engine.SaveDataTypes.Rooms);
            string filePath = System.IO.Path.Combine(savePath, _CurrentRoom.Name + ".room");

            if (System.IO.File.Exists(filePath))
            {
                DialogResult result = MessageBox.Show("File exists! Overwrite?", "Room Designer", MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                    return;
            }
            
            ManagedScripting.XmlSerialization.Save(filePath, _CurrentRoom);
            MessageBox.Show("Saved.", "Room Designer");
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabObjects.SelectedTab.Text == "Script")
            {
                txtScript.Text = _CurrentRoom.Script;
            }
        }
    }
}
