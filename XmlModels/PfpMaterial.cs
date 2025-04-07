using System.Xml;
using System.Xml.Serialization;
using PfpToDbService;

namespace PfpReader.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class PfpMaterial
    {
        /// <summary />
        [XmlAttribute] 
        public string Name { get; set; } = string.Empty;
        /// <summary />
        [XmlAttribute("Material_ID")]
        public string MaterialId { get; set; } = string.Empty;
        /// <summary />
        [XmlAttribute]
        public double Density { get; set; }
        /// <summary />
        [XmlAttribute]
        public double YieldStrength { get; set; }
        /// <summary />
        [XmlAttribute]
        public double Hardness { get; set; }
        /// <summary />
        [XmlIgnore]
        public bool Conductivity { get; set; }

        [XmlAttribute(nameof(Conductivity))]
        public string ConductivityString
        {
            get => XmlConvert.ToString(Conductivity);
            set => Conductivity = value.ToBool();
        }
        /// <summary />
        [XmlIgnore]
        public bool PlasticProtection { get; set; }
        [XmlAttribute(nameof(PlasticProtection))]
        public string PlasticProtectionString
        {
            get => XmlConvert.ToString(PlasticProtection);
            set => PlasticProtection = value.ToBool();
        }
        /// <summary />
        [XmlAttribute]
        public double Thickness { get; set; }
    }
}