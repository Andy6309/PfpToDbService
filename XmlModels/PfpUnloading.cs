using System.Collections.Generic;
using System.Xml.Serialization;

namespace PfpReader.Models
{
    public class PfpUnloading
    {
        [XmlElement(ElementName = "UnloadingProcess")]
        public List<PfpUnloadingProcess> UnloadingProcesses = new List<PfpUnloadingProcess>();
    }
}