using System.Collections.Generic;
using App.Model;

namespace App.Saver
{
    public interface ISaver
    {
        string SaveErrorMessage { get; }
        bool Save(IEnumerable<CalculationRecord> data);
    }
}