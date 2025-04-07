using System.Xml.Serialization;

namespace PfpReader.Models
{
    public class PfpBCenteringTools
    {
        [XmlElement]
        public PfpToolingElement Left = new PfpToolingElement();
        [XmlElement]
        public PfpToolingElement Right = new PfpToolingElement();
    }
}