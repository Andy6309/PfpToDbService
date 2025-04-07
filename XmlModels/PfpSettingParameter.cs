using System.Xml.Serialization;

namespace PfpReader.Models
{
    public class PfpSettingParameter
    {
        [XmlAttribute]
        public string Name { get; set; } = string.Empty;
        [XmlAttribute]
        public string Type { get; set; } = string.Empty;
        [XmlAttribute]
        public string Value { get; set; } = string.Empty;
        [XmlAttribute]
        public string NominalValue { get; set; } = string.Empty;
    }
}