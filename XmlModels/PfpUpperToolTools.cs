using System.Xml.Serialization;

namespace PfpReader.Models
{
    public class PfpUpperToolTools
    {
        [XmlElement]
        public PfpToolingElement LowerTool = new PfpToolingElement();
        [XmlElement]
        public PfpUpperTools UpperTools = new PfpUpperTools();
    }
}