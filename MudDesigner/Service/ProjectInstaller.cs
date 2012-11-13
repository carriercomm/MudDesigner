﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace Service
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();

            serviceProcessInstaller1.Account = ServiceAccount.LocalSystem;
            serviceInstaller1.ServiceName = "Mud Designer Service";
            Installers.Add(serviceInstaller1);
        }
    }
}
