using System.Xml.Serialization;

namespace PfpReader.Models
{
    public class PfpNcLine
    {
        [XmlAttribute]
        public string Line;
    }
}