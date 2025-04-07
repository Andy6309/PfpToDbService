using System.Collections.Generic;
using System.Xml.Serialization;

namespace PfpReader.Models
{
    public class PfpBendSequence
    {
        [XmlElement("BendProcess")]
        public List<PfpBendProcess> BendProcesses { get; set; }
        [XmlElement("BxNcLine")]
        public List<PfpNcLine> BxNcLines { get; set; }
    }
}