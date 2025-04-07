using System.Xml;
using System.Xml.Serialization;
using PfpToDbService;

namespace PfpReader.Models
{
    public class PfpCamOptions
    {
        [XmlElement]
        public PfpEraseHoles EraseHolesMode { get; set; } = PfpEraseHoles.EraseNone;
        [XmlElement]
        public PfpEraseFormings EraseFormingsMode { get; set; } = PfpEraseFormings.EraseNone;
        [XmlIgnore]
        public bool AllowFreeBends { get; set; }
        [XmlElement(nameof(AllowFreeBends))]
        public string AllowFreeBendsString
        {
            get => XmlConvert.ToString(AllowFreeBends);
            set => AllowFreeBends = value.ToBool();
        }

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

        [XmlIgnore]
        public bool ForceKeepAsp { get; set; } = true;
        [XmlElement("ForceKeepASP")]
        public string ForceKeepAspString
        {
            get => XmlConvert.ToString(ForceKeepAsp);
            set => ForceKeepAsp = value.ToBool();
        } 
        [XmlIgnore]
        public bool ForceKeepAut { get; set; } = true;
        [XmlElement("ForceKeepAUT")]
        public string ForceKeepAutString
        {
            get => XmlConvert.ToString(ForceKeepAut);
            set => ForceKeepAut = value.ToBool();
        }

        [XmlIgnore]
        public bool ForceKeepToolCompose { get; set; }
        [XmlElement(nameof(ForceKeepToolCompose))]
        public string ForceKeepToolComposeString
        {
            get => XmlConvert.ToString(ForceKeepToolCompose);
            set => ForceKeepToolCompose = value.ToBool();
        }

        [XmlElement]
        public PfpCamChildOption[] ChildOptions = { };
    }
}