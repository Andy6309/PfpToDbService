using System.Xml.Serialization;

namespace PfpReader.Models
{
    public class PfpToolingElement
    {
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute("ID")]
        public string Id { get; set; }
        [XmlAttribute] 
        public double Position { get; set; } = double.NaN;
        [XmlAttribute] 
        public double Dimension { get; set; } = double.NaN;
    }
}