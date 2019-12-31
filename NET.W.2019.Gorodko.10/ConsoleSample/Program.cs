using System.IO;
using Data.Load;
using Data.Parsing;
using Data.Parsing.Converting;
using Data.Parsing.Validation;
using Xml.Export;

namespace ConsoleSample
{
    public class Program
    {
        static void Main(string[] args)
        {
            string path = "test.txt";
            using (var writer = new StreamWriter(File.Create(path)))
            {
                writer.WriteLine("https://github.com/AnzhelikaKravchuk?tab=repositories");
                writer.WriteLine("https://github.com/AnzhelikaKravchuk/2017-2018.MMF.BSU");
                writer.WriteLine("https://habrahabr.ru/company/it-grad/blog/341486/");
            }

            var fileLoader = new FileDataLoader(path);
            string dataString = fileLoader.Load();

            var urlParser = new UrlParser(new DefaultUrlConverter(), new DefaultUrlValidator());
            var urls = urlParser.Parse(dataString);

            using (var fs = File.Create("testresult.xml"))
            {
                var exporter = new DefaultXmlExporter(fs);
                exporter.Export(urls);
            }
        }
    }
}
