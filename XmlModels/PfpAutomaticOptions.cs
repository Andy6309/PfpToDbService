using System.Xml;
using System.Xml.Serialization;
using PfpToDbService;

namespace PfpReader.Models
{
    public class PfpAutomaticOptions
    {
        [XmlElement]
        public PfpAutomaticReposition AutomaticRepositionType { get; set; } = PfpAutomaticReposition.ReturnToCenter;
        [XmlElement]
        public PfpFirstAutomaticReposition FirstAutomaticReposition { get; set; } = PfpFirstAutomaticReposition.ManpGrip;
        [XmlIgnore]
        public bool AutoEnterCompacted { get; set; }
        [XmlElement(nameof(AutoEnterCompacted))]
        public string AutoEnterCompactedString
        {
            get => XmlConvert.ToString(AutoEnterCompacted);
            set => AutoEnterCompacted = value.ToBool();
        }
    }
}