using ExcelLibrary.SpreadSheet;
using XmlCharacteristicsGenerator.Model;

namespace XmlCharacteristicsGenerator.Logic
{
    public class ExcelReader
    {
        public static void ReadExcel(string path, List<XmlInfoString> list)
        {
            var book = Workbook.Load(path);
            var sheet = book.Worksheets[0];

            // Итерация по строкам с использованием индекса:
            for (int rowIndex = sheet.Cells.FirstRowIndex + 1; rowIndex <= sheet.Cells.LastRowIndex; rowIndex++)
            {
                var qrString = new XmlInfoString(sheet.Cells.GetRow(rowIndex));
                list.Add(qrString);
            }
        }
    }
}
