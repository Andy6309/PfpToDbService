using System.Xml.Serialization;

namespace PfpReader.Models
{
    public class PfpMCenteringTools
    {
        [XmlElement]
        public PfpToolingElement MainLeft { get; set; } = new PfpToolingElement();
        [XmlElement]
        public PfpToolingElement MainRight { get; set; } = new PfpToolingElement();
        [XmlElement]
        public PfpToolingElement AuxLeft { get; set; } = new PfpToolingElement();
        [XmlElement]
        public PfpToolingElement AuxRight { get; set; } = new PfpToolingElement();
    }
}