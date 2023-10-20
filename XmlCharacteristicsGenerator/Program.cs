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

            var DateStart = DateTime.Now;
            await Console.Out.WriteLineAsync($"Начало процесса: {DateStart}");

            //foreach (var item in xmlList)
            //{
            //    Console.WriteLine($"Формирую файл xml #{filesCount}. {item.ResunId}.");
            //    item.SaveToXmlFile();
            //    filesCount++;                
            //}

            var tasks = xmlList.Select(async item =>
            {
                await Console.Out.WriteLineAsync($"Формирую файл xml #{filesCount}. {item.ResunId}.");
                await item.SaveToXmlFileAsync();
                filesCount++;
            });

            await Task.WhenAll(tasks);

            await Console.Out.WriteLineAsync(new string ('-', 50));
            await Console.Out.WriteLineAsync($"Выполнено. Файлов создано: {filesCount}");

            var DateEnd = DateTime.Now;
            await Console.Out.WriteLineAsync($"Конец процесса: {DateEnd}");
            await Console.Out.WriteLineAsync($"Затрачено времени: {(DateEnd - DateStart).Seconds} с.");

            await Console.In.ReadLineAsync();
        }
    }
}