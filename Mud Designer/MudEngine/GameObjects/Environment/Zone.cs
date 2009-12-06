﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MudDesigner.MudEngine.Objects.Environment
{
    public class Zone : BaseObject
    {
        [System.ComponentModel.Browsable(false)]
        public string Realm
        {
            get;
            set;
        }

        [System.ComponentModel.Browsable(false)]
        public List<Room> Rooms { get; set; }

        public Zone()
        {
            Rooms = new List<Room>();
        }
    }
}
