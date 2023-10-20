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

            using var writer = new StreamWriter(fileName);
            await writer.WriteAsync(element.ToString());
        }

        public static void SaveToXmlFile(this XmlInfoString xmlInfoString)
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

            using var writer = new StreamWriter(fileName);
            writer.Write(element.ToString());
        }
    }
}
