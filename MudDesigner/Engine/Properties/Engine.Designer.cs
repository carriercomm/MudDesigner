﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MudDesigner.Engine.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")]
    public sealed partial class Engine : global::System.Configuration.ApplicationSettingsBase {
        
        private static Engine defaultInstance = ((Engine)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Engine())));
        
        public static Engine Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Game.sav")]
        public string GameSaveFile {
            get {
                return ((string)(this["GameSaveFile"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("MudDesigner.Scripts.Game.Game")]
        public string DefaultGameType {
            get {
                return ((string)(this["DefaultGameType"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("MudDesigner.Scripts.Environment.World")]
        public string DefaultWorldType {
            get {
                return ((string)(this["DefaultWorldType"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("MudDesigner.Scripts.Game.Player")]
        public string DefaultPlayerType {
            get {
                return ((string)(this["DefaultPlayerType"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("MudDesigner.Scripts.States.MainMenuState")]
        public string LoginSuccessState {
            get {
                return ((string)(this["LoginSuccessState"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<ArrayOfString xmlns:xsi=\"http://www.w3." +
            "org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n  <s" +
            "tring>MudDesigner.Scripts.dll</string>\r\n</ArrayOfString>")]
        public global::System.Collections.Specialized.StringCollection ScriptLibrary {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["ScriptLibrary"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Scripts")]
        public string ScriptsPath {
            get {
                return ((string)(this["ScriptsPath"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Bedroom")]
        public string LoginRoom {
            get {
                return ((string)(this["LoginRoom"]));
            }
            set {
                this["LoginRoom"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("MudDesigner.Scripts.Environment.Door")]
        public string DoorType {
            get {
                return ((string)(this["DoorType"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("MudDesigner.Scripts.Environment.Realm")]
        public string RealmType {
            get {
                return ((string)(this["RealmType"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("MudDesigner.Scripts.Environment.Zone")]
        public string ZoneType {
            get {
                return ((string)(this["ZoneType"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("MudDesigner.Scripts.Environment.Room")]
        public string RoomType {
            get {
                return ((string)(this["RoomType"]));
            }
        }
    }
}
