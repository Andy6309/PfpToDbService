using System.Collections.Generic;
using System.Xml.Serialization;

namespace PfpReader.Models
{
    public class PfpFreeBend : PfpBasePhase
    {
        [XmlElement(ElementName = "Phase")]
        public List<PfpPhase> Phases { get; set; }
        [XmlElement]
        public PfpMonitorings Monitorings { get; set; }
        [XmlElement]
        public PfpBends Bends { get; set; }
    }
}