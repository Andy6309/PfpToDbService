using System.Xml.Serialization;

namespace PfpReader.Models
{
    public class PfpUpperTools
    {
        [XmlAttribute("MaxCLL")]
        public double MaxCll { get; set; }

        [XmlAttribute]
        public double MaxCompositionLength { get; set; }

        public PfpToolingElement CentralTool = new PfpToolingElement();

        public PfpToolingElements MobileToolsLeft = new PfpToolingElements();
        public PfpToolingElements MobileToolsRight = new PfpToolingElements();

        public PfpToolingElements FixedToolsLeft = new PfpToolingElements();
        public PfpToolingElements FixedToolsRight = new PfpToolingElements();

        public PfpToolingElement EndToolLeft = new PfpToolingElement();
        public PfpToolingElement EndToolRight = new PfpToolingElement();

        public PfpToolingElements StandardToolsLeft = new PfpToolingElements();
        public PfpToolingElements StandardToolsRight = new PfpToolingElements();
    }
}