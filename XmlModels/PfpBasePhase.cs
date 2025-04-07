using System.Xml.Serialization;

namespace PfpReader.Models
{
    public abstract class PfpBasePhase
    {
        [XmlAttribute]
        public string Type { get; set; } = string.Empty;

        [XmlElement]
        public PfpParameters Parameters { get; set; }
    }
}