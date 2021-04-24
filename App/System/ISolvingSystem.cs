namespace App.System
{
    interface ISolvingSystem
    {
        public double StartingPoint { get; }
        public double EndingPoint { get; }
        public double Step { get; }

        public int NumberOfIterations { get; }
    }
}
