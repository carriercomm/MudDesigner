﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MudEngine.Engine {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "12.0.0.0")]
    public sealed partial class ServerProperties : global::System.Configuration.ApplicationSettingsBase {
        
        private static ServerProperties defaultInstance = ((ServerProperties)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new ServerProperties())));
        
        public static ServerProperties Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("100")]
        public int MaxConnections {
            get {
                return ((int)(this["MaxConnections"]));
            }
            set {
                this["MaxConnections"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("23")]
        public int Port {
            get {
                return ((int)(this["Port"]));
            }
            set {
                this["Port"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("6")]
        public int MinimumPasswordSize {
            get {
                return ((int)(this["MinimumPasswordSize"]));
            }
            set {
                this["MinimumPasswordSize"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("16")]
        public int MaximumPasswordSize {
            get {
                return ((int)(this["MaximumPasswordSize"]));
            }
            set {
                this["MaximumPasswordSize"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::System.Collections.Specialized.StringCollection MessageOfTheDay {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["MessageOfTheDay"]));
            }
            set {
                this["MessageOfTheDay"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("6")]
        public int MaxQueuedConnections {
            get {
                return ((int)(this["MaxQueuedConnections"]));
            }
            set {
                this["MaxQueuedConnections"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Scionwest")]
        public string Owner {
            get {
                return ((string)(this["Owner"]));
            }
            set {
                this["Owner"] = value;
            }
        }
    }
}
