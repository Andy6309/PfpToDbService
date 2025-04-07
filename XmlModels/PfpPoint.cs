using System.Xml.Serialization;

namespace PfpReader.Models
{
    public class PfpPoint
    {
        [XmlAttribute]
        public double X { get; set; }
        [XmlAttribute]
        public double Y { get; set; }
        [XmlAttribute]
        public double Z { get; set; }
    }
}