namespace App.System
{
    interface ISolvingSystemData
    {
        double StartingPoint { get; }
        double EndingPoint { get; }
        double Step { get; }
        int NumberOfIterations { get; }
    }
}
