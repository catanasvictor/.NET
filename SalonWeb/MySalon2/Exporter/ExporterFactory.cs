namespace SalonWeb.Exporter
{
    public class ExporterFactory
    {
        public IExporter createExporter(int x)
        {
            if (x == 1) return new ExportJson();
            else if (x == 2) return new CsvExporter();
                 else return new ExportXml();
        }
    }
}
