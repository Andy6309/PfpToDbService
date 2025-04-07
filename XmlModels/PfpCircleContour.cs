using System.Xml.Serialization;

namespace PfpReader.Models
{
    public class PfpCircleContour : PfpContourElement
    {
        [XmlAttribute]
        public double X1 { get; set; }
        [XmlAttribute]
        public double Y1 { get; set; }
        [XmlAttribute]
        public double Xc { get; set; }
        [XmlAttribute]
        public double Yc { get; set; }
    }
}