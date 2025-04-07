using System.Xml.Serialization;

namespace PfpReader.Models
{
    public class PfpNcBendExpressLine
    {
        [XmlAttribute]
        public string Line { get; set; }
    }
}