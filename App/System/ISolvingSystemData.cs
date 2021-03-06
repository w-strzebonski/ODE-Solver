namespace App.System
{
    public interface ISolvingSystemData
    {
        double StartingPoint { get; }
        double EndingPoint { get; }
        double Step { get; }
        int NumberOfIterations { get; }
    }
}
