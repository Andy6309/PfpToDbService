using System.Xml.Serialization;

namespace PfpReader.Models
{
    public class PfpPartRef
    {
        [XmlAttribute]
        public double RefPosX { get; set; }
        [XmlAttribute]
        public double RefPosY { get; set; }
    }
}