using XmlCharacteristicsGenerator.Logic;
using XmlCharacteristicsGenerator.Model;

namespace XmlCharacteristicsGenerator
{
    internal class Program
    {
        static async Task Main()
        {
            var xmlList = new List<XmlInfoString>();
            ExcelReader.ReadExcel($"C:\\HAR.xls", xmlList);
            var filesCount = 0;

            var tasks = xmlList.Select(async item =>
            {
                await item.SaveToXmlFileAsync();
                filesCount++;
            });

            await Task.WhenAll(tasks);

            Console.WriteLine("SUCCESS!");
            Console.WriteLine($"Files created: {filesCount}");

            Console.ReadKey();
        }
    }
}