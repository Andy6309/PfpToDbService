using System.Xml.Serialization;

namespace PfpReader.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class PfpVersion
    {
        /// <summary />
        [XmlAttribute]
        public string Value { get; set; } = string.Empty;
    }
}