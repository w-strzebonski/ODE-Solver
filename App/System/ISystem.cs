using System;
using System.Collections.Generic;
using System.Text;

namespace App.System
{
    interface ISystem
    {
        public double StartingPoint { get; }
        public double EndingPoint { get; }
        public double Step { get; }
    }
}
