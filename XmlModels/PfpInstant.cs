using System.Xml.Serialization;

namespace PfpReader.Models
{
    public enum PfpInstant
    {
        [XmlEnum("start")]
        Start,
        [XmlEnum("end")]
        End
    }
}