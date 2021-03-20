using System;
using System.Collections.Generic;
using System.Text;

namespace App.Interfaces
{
    interface IExactSolutionResolver : IResolver
    {
        IEquation ExactSolutionEquation { get; }
    }
}
