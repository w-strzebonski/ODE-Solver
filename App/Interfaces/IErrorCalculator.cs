namespace App.Interfaces
{
    interface IErrorCalculator
    {
        (double, double)[] Data { get; }

        bool Calculate();
    }
}
