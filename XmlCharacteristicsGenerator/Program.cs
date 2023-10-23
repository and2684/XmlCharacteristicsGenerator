using System.Text;
using XmlCharacteristicsGenerator.Logic;
using XmlCharacteristicsGenerator.Model;

namespace XmlCharacteristicsGenerator
{
    internal class Program
    {
        static async Task Main()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var xmlList = new List<XmlInfoString>();
            ExcelReader.ReadExcel($"C:\\HAR.xls", xmlList);

            var DateStart = DateTime.Now;
            await Console.Out.WriteLineAsync($"Начало процесса: {DateStart}");

            var tasks = xmlList.Select(async (item, index) => // index нужен для правильного указания номера формируемой xml. код асинхронный и простой счетчик тут не работает
            {
                Console.WriteLine($"Формирую файл xml #{index}. {item.ResunId}.");
                await item.SaveToXmlFileAsync();
            }).ToArray(); // Преобразуем результат Select в массив задач.

            await Task.WhenAll(tasks);

            var DateEnd = DateTime.Now;
            await Console.Out.WriteLineAsync(new string('-', 50));
            await Console.Out.WriteLineAsync($"Выполнено. Файлов создано: {xmlList.Count}");

            await Console.Out.WriteLineAsync($"Конец процесса: {DateEnd}");
            await Console.Out.WriteLineAsync($"Затрачено времени: {(DateEnd - DateStart).Seconds} с.");

            await Console.In.ReadLineAsync();
        }
    }
}