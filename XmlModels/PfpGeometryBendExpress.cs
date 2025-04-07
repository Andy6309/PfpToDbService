using System.Xml.Serialization;

namespace PfpReader.Models
{
    public class PfpGeometryBendExpress
    {
        [XmlAttribute] 
        public string DrgFileName { get; set; } = string.Empty;
        [XmlAttribute] 
        public string DrgData { get; set; } = string.Empty;
        [XmlAttribute]
        public string DxfData { get; set; } = string.Empty;
    }
}