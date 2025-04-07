using System.Xml.Serialization;

namespace PfpReader.Models
{
    public class PfpBracketToolingElement : PfpToolingElement
    {
        [XmlAttribute]
        public double LengthPositive { get; set; }
        [XmlAttribute]
        public double LengthNegative { get; set; }
        [XmlAttribute]
        public double CarriageLength { get; set; }
    }
}