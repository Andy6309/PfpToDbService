using System.Collections.Generic;
using System.Xml.Serialization;

namespace PfpReader.Models
{
    public class PfpDevice
    {
        [XmlAttribute]
        public string Name { get; set; } = string.Empty;
        [XmlAttribute("ID")]
        public string Id { get; set; } = string.Empty;
        [XmlElement(ElementName = "Axis")]
        public List<PfpAxis> Axes = new List<PfpAxis>();
    }
}