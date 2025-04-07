using System.Collections.Generic;
using System.Xml.Serialization;

namespace PfpReader.Models
{
    public class PfpCompatibility
    {
        [XmlElement]
        public List<PfpBracket> Brackets { get; set; } = new List<PfpBracket>();
    }
}