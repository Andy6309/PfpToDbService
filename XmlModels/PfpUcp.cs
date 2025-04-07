using System.Xml.Serialization;

namespace PfpReader.Models
{
    public class PfpUcp : PfpToolingElement
    {
        [XmlAttribute]
        public PfpHorizontalSide HorizontalSide { get; set; }
    }
}