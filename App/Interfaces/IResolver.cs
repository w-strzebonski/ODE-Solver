namespace App.Interfaces
{
    interface IResolver
    {
        (double, double)[] Data { get; }

        void Execute(double[] initialConditions);
    }
}
