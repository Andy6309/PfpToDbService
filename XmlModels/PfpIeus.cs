using System.Collections.Generic;
using System.Xml.Serialization;

namespace PfpReader.Models
{
    public class PfpIeus
    {
        [XmlElement(Type = typeof(PfpIeu), ElementName = "IEU")]
        [XmlElement(Type = typeof(PfpIEuEasy), ElementName = "IEU_EASY")]
        public List<PfpToolingElement> IEus { get; set; }
    }
}