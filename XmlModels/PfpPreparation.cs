using System.Collections.Generic;
using System.Xml.Serialization;

namespace PfpReader.Models
{
    public class PfpPreparation
    {
        [XmlElement(ElementName = "Phase")]
        public List<PfpPhase> Phases = new List<PfpPhase>();
    }
}