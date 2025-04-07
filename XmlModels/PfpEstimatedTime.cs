using System.Xml.Serialization;

namespace PfpReader.Models
{
    public class PfpEstimatedTime
    {
        [XmlAttribute]
        public double Value { get; set; }
    }
}