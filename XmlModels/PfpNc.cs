using System.Xml.Serialization;

namespace PfpReader.Models
{
    public class PfpNc
    {
        [XmlAttribute]
        public PfpCreator Creator { get; set; }
        [XmlAttribute]
        public PfpCellConfiguration CellConfiguration { get; set; }
        [XmlAttribute]
        public PfpBenderModel BenderModel { get; set; }
        [XmlElement]
        public PfpSettings Settings { get; set; } = new PfpSettings();
        [XmlElement]
        public PfpLoading Loading { get; set; }
        [XmlElement]
        public PfpBendSequence BendSequence { get; set; } = new PfpBendSequence();
        [XmlElement]
        public PfpUnloading Unloading { get; set; } = new PfpUnloading();
    }
}