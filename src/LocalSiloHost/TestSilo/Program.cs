﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSilo
{
    class Program
    {
        static int Main(string[] args)
        {
            return Piraeus.SiloHost.Silo.Run(args);
        }
    }
}