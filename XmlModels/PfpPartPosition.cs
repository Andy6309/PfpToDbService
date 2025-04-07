using System.Xml.Serialization;

namespace PfpReader.Models
{
    public class PfpPartPosition
    {
        [XmlAttribute]
        public double X { get; set; }
        [XmlAttribute]
        public double Y { get; set; }
        [XmlAttribute]
        public double Z { get; set; }
        [XmlAttribute]
        public double Rx { get; set; }
        [XmlAttribute]
        public double Ry { get; set; }
        [XmlAttribute]
        public double Rz { get; set; }
        [XmlElement]
        public PfpPartRef RefElement { get; set; } = new PfpPartRef();
    }
}