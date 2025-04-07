using System.Collections.Generic;
using System.Xml.Serialization;

namespace PfpReader.Models
{
    public class PfpUcps
    {
        [XmlElement(Type = typeof(PfpUcp), ElementName = "UCP")]
        public List<PfpToolingElement> Ucps { get; set; }
    }
}