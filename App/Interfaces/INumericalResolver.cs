using System;
using System.Collections.Generic;
using System.Text;

namespace App.Interfaces
{
    interface INumericalResolver : IResolver
    {
        ISolver DifferentialSolver { get; }
    }
}
