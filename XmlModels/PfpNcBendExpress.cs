using System.Collections.Generic;
using System.Xml.Serialization;

namespace PfpReader.Models
{
    public class PfpNcBendExpress
    {
        [XmlElement(ElementName = "NCLine")]
        public List<PfpNcBendExpressLine> NcLines { get; set; }
    }
}