using System.Collections.Generic;
using System.Xml.Serialization;

namespace PfpReader.Models
{
    public class PfpMonitoring
    {
        [XmlAttribute]
        public PfpInstant Instant { get; set; }

        [XmlAttribute]
        public bool HumanInteraction
        {
            get => _humanInteraction.HasValue && _humanInteraction.Value;
            set => _humanInteraction = value;
        }

        [XmlElement]
        public PfpPart Part { get; set; } = new PfpPart();

        [XmlArrayItem(ElementName = "Device")]
        public List<PfpDevice> Devices = new List<PfpDevice>();

        [XmlArrayItem(ElementName = "Point")]
        public List<PfpPoint> Points = new List<PfpPoint>();

        #region XmlIgnore
        [XmlIgnore]
        public bool HumanInteractionSpecified => _humanInteraction.HasValue;

        private bool? _humanInteraction;
        #endregion
    }
}