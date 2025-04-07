using System.Xml.Serialization;

namespace PfpReader.Models
{
    public abstract class PfpIeuBase : PfpToolingElement
    {
        [XmlAttribute]
        public PfpHorizontalSide HorizontalSide { get; set; }
        [XmlAttribute]
        public double MountingPosition { get; set; }
        [XmlAttribute]
        public PfpWheelLocation WheelLocation { get; set; }
        [XmlAttribute]
        public double WheelPosition { get; set; }
    }
}