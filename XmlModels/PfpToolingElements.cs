using System.Collections.Generic;
using System.Xml.Serialization;

namespace PfpReader.Models
{
    public class PfpToolingElements
    {
        [XmlAttribute]
        public string Name { get; set; }

        [XmlAttribute("ID")]
        public string Id { get; set; }

        [XmlElement(ElementName = "Segment")]
        public List<PfpToolingElement> Segments;
    }
}