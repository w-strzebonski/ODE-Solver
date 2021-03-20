using System;
using System.Collections.Generic;
using System.Text;

namespace App.Interfaces
{
    interface IErrorCalculator
    {
        (double, double)[] Data { get; }

        bool Calculate();
    }
}
