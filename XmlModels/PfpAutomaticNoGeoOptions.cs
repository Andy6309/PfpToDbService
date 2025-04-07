using System.Xml.Serialization;

namespace PfpReader.Models
{
    public class PfpAutomaticNoGeoOptions
    {
        [XmlElement]
        public PfpAutomaticReposition AutomaticRepositionType { get; set; } = PfpAutomaticReposition.ReturnToCenter;
        [XmlElement]
        public PfpFirstAutomaticReposition FirstAutomaticReposition { get; set; } = PfpFirstAutomaticReposition.ManpGrip;
        [XmlElement]
        public bool AutoEnterCompacted { get; set; }
    }
}