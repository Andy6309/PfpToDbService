using System.Collections.Generic;
using System.Xml.Serialization;

namespace PfpReader.Models
{
    public class PfpBends
    {
        [XmlElement(ElementName = "Bend")]
        public List<PfpBend> Bends;
    }
}