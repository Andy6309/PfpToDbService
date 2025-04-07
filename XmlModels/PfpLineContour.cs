using System.Xml.Serialization;

namespace PfpReader.Models
{
    /// <summary>
    /// Line class
    /// </summary>
    public class PfpLineContour : PfpContourElement
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
        public double Length { get; set; }  // Line lenght [mm]
    }
}