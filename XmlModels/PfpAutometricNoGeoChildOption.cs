using System.Xml;
using System.Xml.Serialization;
using PfpToDbService;

namespace PfpReader.Models
{
    public class PfpAutometricNoGeoChildOption
    {
        [XmlAttribute]
        public string Parameters { get; set; } = string.Empty;

        [XmlIgnore]
        public bool AvoidPieceCollisionsCheck { get; set; }

        [XmlAttribute(nameof(AvoidPieceCollisionsCheck))]
        public string AvoidPieceCollisionsCheckString
        {
            get => XmlConvert.ToString(AvoidPieceCollisionsCheck);
            set => AvoidPieceCollisionsCheck = value.ToBool();
        }
    }
}