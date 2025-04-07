using System.Xml.Serialization;

namespace PfpReader.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class PfpHeader
    {
        /// <summary />
        [XmlAttribute]
        public string PieceName { get; set; } = string.Empty;
        /// <summary />
        [XmlAttribute]
        public string PieceDescription { get; set; } = string.Empty;
        /// <summary />
        [XmlAttribute]
        public string Barcode { get; set; } = string.Empty;
        /// <summary />
        [XmlElement]
        public PfpVersion Version { get; set; } = new PfpVersion();
        /// <summary />
        [XmlElement]
        public PfpMaterial Material { get; set; } = new PfpMaterial();
        /// <summary />
        [XmlElement]
        public PfpSpecial Special { get; set; } = new PfpSpecial();
        /// <summary />
        [XmlElement]
        public PfpEstimatedTime EstimatedTime { get; set; } = new PfpEstimatedTime();
    }
}