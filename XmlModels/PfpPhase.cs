using System.Xml.Serialization;

namespace PfpReader.Models
{
    public class PfpPhase : PfpBasePhase
    {
        [XmlAttribute]
        public double Angle { get; set; } = double.NaN;
        [XmlAttribute("FlowID")]
        public string FlowId { get; set; } = string.Empty;
        [XmlElement]
        public PfpMonitorings Monitorings { get; set; }
        [XmlElement]
        public PfpBends Bends { get; set; }
    }
}