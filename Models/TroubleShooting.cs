﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MESInfoCenter.Models
{
    public class TroubleShooting
    {
        public int tsID { get; set; }
        public int appID { get; set; }
        public string tsTitle {  get; set; }
        public string tsErrorTag { get; set; }
        public string tsDescription { get; set; }
        public string tsSolution { get; set; }

    }
}
