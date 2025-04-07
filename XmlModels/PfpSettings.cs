using System.Collections.Generic;
using System.Xml.Serialization;

namespace PfpReader.Models
{
    public class PfpSettings
    {
        [XmlElement(ElementName = "Setting")]
        public List<PfpSettingParameter> Settings { get; set; } = new List<PfpSettingParameter>();
    }
}