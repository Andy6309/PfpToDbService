using System.Dynamic;
using System.Xml;
using System.Xml.Serialization;
using PfpToDbService;

namespace PfpReader.Models
{
    public class PfpTooling
    {
        [XmlAttribute]
        public string Creator { get; set; }
        [XmlAttribute]
        public PfpCellConfiguration CellConfiguration { get; set; }
        [XmlAttribute]
        public PfpBenderModel BenderModel { get; set; }
        [XmlAttribute]
        public string CellName { get; set; }
        [XmlAttribute]
        public string MachineName { get; set; }
        [XmlIgnore]
        public bool ToolsCollisionsChecked { get; set; }
        [XmlAttribute(nameof(ToolsCollisionsChecked))]
        public string ToolsCollisionsCheckedString
        {
            get => XmlConvert.ToString(ToolsCollisionsChecked);
            set => ToolsCollisionsChecked = value.ToBool();
        }

        [XmlElement] 
        public PfpBenderTools BenderTools { get; set; } = new PfpBenderTools();
        [XmlElement]
        public PfpManipulatorTools ManipulatorTools { get; set; }
    }
}