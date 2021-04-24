namespace App.System
{
    interface ISolvingSystemData
    {
        public double StartingPoint { get; }
        public double EndingPoint { get; }
        public double Step { get; }
        public int NumberOfIterations { get; }
    }
}
