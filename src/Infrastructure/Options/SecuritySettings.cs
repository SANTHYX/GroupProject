﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Options
{
    public class SecuritySettings
    {
        public static string Section => "AuthentionToken";
        public string Key { get; set; }
    }
}
