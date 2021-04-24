﻿using System;
using System.Collections.Generic;
using System.Text;

namespace App.Interfaces
{
    interface IResolver
    {
        (double, double)[] Data { get; }

        void Execute(double[] initialConditions);
    }
}
