using System.Xml;
using System.Xml.Serialization;
using PfpToDbService;

namespace PfpReader.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class PfpSpecial
    {
        [XmlIgnore]
        public bool TurnOver { get; set; }
        [XmlAttribute(nameof(TurnOver))]
        public string TurnOverString
        {
            get => XmlConvert.ToString(TurnOver);
            set => TurnOver = value.ToBool();
        }
    }
}