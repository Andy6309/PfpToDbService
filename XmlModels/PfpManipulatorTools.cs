using System.Xml.Serialization;

namespace PfpReader.Models
{
    public class PfpManipulatorTools
    {
        [XmlElement]
        public PfpToolingElement Rotator { get; set; } = new PfpToolingElement();
        [XmlElement]
        public PfpToolingElement Clamp { get; set; } = new PfpToolingElement();
        [XmlElement]
        public PfpMCenteringTools CenteringTools { get; set; } = new PfpMCenteringTools();
    }
}