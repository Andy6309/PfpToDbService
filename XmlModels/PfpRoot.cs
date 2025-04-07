using System.Xml;
using System.Xml.Serialization;

namespace PfpReader.Models
{
    /// <summary>
    /// 
    /// </summary>
    [XmlRoot("Root")]
    public class PfpRoot
    {
        /// <summary />
        [XmlElement]
        public PfpHeader Header { get; set; } = new PfpHeader();

        //       [XmlElement]
        //       public PfpGeometryBendExpress GeometryBendExpress { get; set; } 

        [XmlElement]
        public PfpTooling Tooling { get; set; }

        [XmlElement("NC")]
        public PfpNc Nc { get; set; }

        //    [XmlElement("NCBendExpress")]
        //    public PfpNcBendExpress NcBendExpress { get; set; }

        /// <summary />
        //     [XmlElement]
        //     public PfpGeometry2D Geometry2D { get; set; }

        /// <summary />
        [XmlElement]
        public PfpParametric Parametric { get; set; }
    }
}
