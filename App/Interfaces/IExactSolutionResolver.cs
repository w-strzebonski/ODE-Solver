namespace App.Interfaces
{
    interface IExactSolutionResolver : IResolver
    {
        IEquation ExactSolutionEquation { get; }
    }
}
