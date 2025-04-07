using System.Xml;
using System.Xml.Serialization;
using PfpToDbService;

namespace PfpReader.Models
{
    public class PfpCamChildOption
    {
        [XmlAttribute]
        public double X { get; set; }
        [XmlAttribute]
        public double Y { get; set; }
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