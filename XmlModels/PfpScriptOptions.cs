using System.Xml;
using System.Xml.Serialization;
using PfpToDbService;

namespace PfpReader.Models
{
    public class PfpScriptOptions
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
    }
}