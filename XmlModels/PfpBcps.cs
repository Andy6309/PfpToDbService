using System.Collections.Generic;
using System.Xml.Serialization;

namespace PfpReader.Models
{
    public class PfpBcps
    {
        [XmlElement(Type = typeof(PfpBcp), ElementName = "BCP")]
        public List<PfpToolingElement> Bcps;
    }
}