using System.Collections.Generic;
using System.Xml.Serialization;

namespace PfpReader.Models
{
    public class PfpBracket
    {
        [XmlAttribute]
        public string Name { get; set; } = string.Empty;
        [XmlAttribute]
        public PfpHorizontalSide HorizontalSide { get; set; }
        [XmlAttribute]
        public PfpVerticalSide VerticalSide { get; set; }
        [XmlArrayItem(ElementName = "Blade")]
        public List<PfpToolingElement> Blades = new List<PfpToolingElement>();
    }
}