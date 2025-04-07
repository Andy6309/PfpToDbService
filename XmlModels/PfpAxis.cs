using System.Xml.Serialization;

namespace PfpReader.Models
{
    public class PfpAxis
    {
        [XmlAttribute] 
        public string Name { get; set; } = string.Empty;
        [XmlAttribute("ID")] 
        public string Id { get; set; } = string.Empty;
        [XmlAttribute]
        public double Value { get; set; }
    }
}