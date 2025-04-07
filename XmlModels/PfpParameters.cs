using System.Collections.Generic;
using System.Xml.Serialization;

namespace PfpReader.Models
{
    public class PfpParameters
    {
        [XmlElement(ElementName = "Parameter")]
        public List<PfpSettingParameter> Parameters { get; set; }
    }
}