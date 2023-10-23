using System.Text;
using System.Xml.Linq;
using XmlCharacteristicsGenerator.Model;

namespace XmlCharacteristicsGenerator.Logic
{
    public static class XmlGenerator
    {
        public static async Task SaveToXmlFileAsync(this XmlInfoString xmlInfoString)
        {
            var element = new XElement("objects",
                new XElement("object",
                    new XAttribute("action", "INSERT"),
                    new XAttribute("pipeto", "cat_send"),
                    new XElement("obj_name", "RESHAR"),
                    new XElement("fields",
                        new XElement("ID", ""),
                        new XElement("RESUN_ID", xmlInfoString.ResunId),
                        new XElement("TYPEDESCR", xmlInfoString.Typedescr),
                        new XElement("VALUE", xmlInfoString.Value),
                        new XElement("VALUETO", ""),
                        new XElement("UNIT_ID", xmlInfoString.UnitId),
                        new XElement("FLAGREQUIRED", xmlInfoString.FlagRequired)
                    ),
                    new XElement("spec", " ")
                )
            );

            var fileName = Path.Combine("C:\\HARS", $"{xmlInfoString.ResunId[..11]}.xml");

            // Создаем новый экземпляр кодировки Windows-1251
            Encoding windows1251 = Encoding.GetEncoding(1251);

            // Создаем StringWriter для записи XML
            using var xmlWriter = new StringWriter();

            // Записываем объявление кодировки в начале
            xmlWriter.Write("<?xml version=\"1.0\" encoding=\"windows-1251\" ?>\n");
            // Записываем XML элемент
            xmlWriter.Write(element);

            // Записываем в файл
            await File.WriteAllTextAsync(fileName, xmlWriter.ToString(), windows1251);
        }
    }
}
