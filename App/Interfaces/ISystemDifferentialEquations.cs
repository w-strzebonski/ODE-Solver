namespace App.Interfaces
{
    interface ISystemDifferentialEquations
    {
        IEquation[] Equations { get; }

        double[] Calculate(double[] input);
    }
}
