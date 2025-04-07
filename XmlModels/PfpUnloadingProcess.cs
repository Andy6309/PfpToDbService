using System.Xml.Serialization;

namespace PfpReader.Models
{
    public class PfpUnloadingProcess
    {
        [XmlAttribute]
        public string Type { get; set; }
        [XmlElement]
        public PfpPreparation Preparation { get; set; } = new PfpPreparation();
        [XmlElement]
        public PfpPhase UnloadingPhase { get; set; }
    }
}