using System.Xml;
using System.Xml.Serialization;
using PfpToDbService;

namespace PfpReader.Models
{
    public class PfpBcp : PfpToolingElement
    {
        [XmlAttribute]
        public PfpHorizontalSide HorizontalSide { get; set; }

        [XmlIgnore]
        public bool PlateOpened { get; set; }

        [XmlAttribute(nameof(PlateOpened))]
        public string PlateOpenedString
        {
            get => XmlConvert.ToString(PlateOpened);
            set => PlateOpened = value.ToBool();
        }
    }
}