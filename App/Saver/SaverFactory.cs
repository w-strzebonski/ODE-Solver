namespace App.Saver
{
    public static class SaverFactory
    {
        public static ISaver CreateCsvSaver()
        {
            return CsvSaver.Create();
        }
    }
}