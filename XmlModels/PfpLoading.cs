using System.Collections.Generic;
using System.Xml.Serialization;

namespace PfpReader.Models
{
    public class PfpLoading
    {
        [XmlElement(ElementName = "LoadingPhase")]
        public List<PfpPhase> LoadingPhases;
    }
}