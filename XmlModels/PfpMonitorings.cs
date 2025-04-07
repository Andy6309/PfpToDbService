using System.Collections.Generic;
using System.Xml.Serialization;

namespace PfpReader.Models
{
    public class PfpMonitorings
    {
        [XmlElement(ElementName = "Monitoring")]
        public List<PfpMonitoring> Monitorings { get; set; }
    }
}