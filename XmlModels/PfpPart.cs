using System.Xml.Serialization;

namespace PfpReader.Models
{
    public class PfpPart
    {   
        [XmlElement]
        public PfpBends Bends = new PfpBends();
        [XmlElement]
        public PfpPartPosition Position = new PfpPartPosition();
    }
}