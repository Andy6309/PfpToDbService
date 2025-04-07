using System.Xml.Serialization;

namespace PfpReader.Models
{
    public class PfpIeu : PfpIeuBase
    {
        [XmlAttribute]
        public PfpScrewLocation ScrewLocation { get; set; }
    }
}