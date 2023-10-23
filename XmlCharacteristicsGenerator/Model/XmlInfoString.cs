using ExcelLibrary.SpreadSheet;

namespace XmlCharacteristicsGenerator.Model
{
    public class XmlInfoString
    {
        public string ResunId { get; set; }
        public string Typedescr { get; set; }
        public string Value { get; set; }
        public string UnitId { get; set; }
        public string FlagRequired { get; set; }
        public XmlInfoString(Row xmlRow)
        {
            ResunId = xmlRow.GetCell(0).Value?.ToString() ?? string.Empty;
            Typedescr = xmlRow.GetCell(1).Value?.ToString() ?? string.Empty;
            Value = xmlRow.GetCell(2).Value?.ToString() ?? string.Empty;
            UnitId = xmlRow.GetCell(3).Value?.ToString() ?? string.Empty;
            FlagRequired = xmlRow.GetCell(4).Value?.ToString() ?? string.Empty;
        }
    }


}
