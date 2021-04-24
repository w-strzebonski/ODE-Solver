namespace App.Interfaces
{
    interface INumericalResolver : IResolver
    {
        ISolver DifferentialSolver { get; }
    }
}
