using System.Collections.Generic;
using System.Xml.Serialization;

namespace PfpReader.Models
{
    public class PfpBendProcess
    {
        [XmlAttribute]
        public string Type { get; set; } = string.Empty;
        [XmlAttribute]
        public double RotationAngle { get; set; }
        [XmlElement]
        public PfpPreparation Preparation { get; set; } = new PfpPreparation();
        [XmlElement(Type = typeof(PfpPhase), ElementName = "BendPhase")]
        [XmlElement(Type = typeof(PfpFreeBend), ElementName = "FreeBend")]
        public List<PfpBasePhase> BendPhases { get; set; } = new List<PfpBasePhase>();
    }
}