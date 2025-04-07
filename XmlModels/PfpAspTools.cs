using System.Xml.Serialization;

namespace PfpReader.Models
{
    public class PfpAspTools
    {
        [XmlElement]
        public PfpCompatibility Compatibility { get; set; }
        [XmlElement]
        public PfpBracketCouple BracketsCouplesLeft { get; set; }
        [XmlElement]
        public PfpBracketCouple BracketsCouplesRight { get; set; }
    }
}