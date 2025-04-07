using System.Collections.Generic;
using System.Xml.Serialization;

namespace PfpReader.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class PfpGeometry2D
    {
        [XmlElement]
        public PfpGeometry2DSize Size { get; set; } = new PfpGeometry2DSize();

        [XmlElement("Contour")]
        public List<PfpContour> Contours { get; set; } = new List<PfpContour>();
    }
}