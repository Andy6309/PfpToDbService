using System.Xml.Serialization;

namespace PfpReader.Models
{
    /// <summary>
    /// Arc class
    /// </summary>
    public class PfpArcContour : PfpContourElement
    {
        [XmlAttribute]
        public double X1 { get; set; }
        [XmlAttribute]
        public double Y1 { get; set; }
        [XmlAttribute]
        public double X2 { get; set; }
        [XmlAttribute]
        public double Y2 { get; set; }
        [XmlAttribute]
        public double Xc { get; set; }      // Arc X center point [mm]
        [XmlAttribute]
        public double Yc { get; set; }      // Arc Y center point [mm]
        [XmlAttribute]
        public int Dir { get; set; }      // Arc direction clockwise and anticlockwise
        [XmlAttribute]
        public double Length { get; set; }  // Arc lenght [mm]
    }
}