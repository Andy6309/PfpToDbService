using System.Xml.Serialization;

namespace PfpReader.Models
{
    public class PfpBracketCouple
    {
        [XmlElement]
        public PfpBracketToolingElement UpperBracket { get; set; }
        [XmlElement]
        public PfpToolingElements UpperBlades { get; set; }
        [XmlElement]
        public PfpBracketToolingElement LowerBracket { get; set; }
        [XmlElement]
        public PfpToolingElements LowerBlades { get; set; }
    }
}