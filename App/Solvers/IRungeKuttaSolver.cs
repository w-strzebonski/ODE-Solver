namespace App.Solvers
{
    interface IRungeKuttaSolver : ISolver
    {
        double[] aCoefficients { get; }
        double[] bCoefficients { get; }
        double[,] cCoeficcients { get; }
    }
}
