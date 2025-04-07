using System.Xml.Serialization;

namespace PfpReader.Models
{
    public class PfpBenderTools
    {
        [XmlElement]
        public PfpToolingElement UpperBlade = new PfpToolingElement();
        [XmlElement]
        public PfpToolingElement LowerBlade = new PfpToolingElement();
        [XmlElement]
        public PfpUpperToolTools UpperToolTools = new PfpUpperToolTools();
        
        [XmlElement]
        public PfpBCenteringTools CenteringTools { get; set; }

        [XmlElement("ASPTools")]
        public PfpAspTools AspTools { get; set; }
        
        [XmlElement("AUTTools")]
        public PfpToolingElements AutTools { get; set; }
        
        [XmlElement("BCPs")]
        public PfpBcps Bcps { get; set; }
        
        [XmlElement("UCPs")]
        
        public PfpUcps Ucps { get; set; }
       
        [XmlElement("IEUs")]
        public PfpIeus Ieus { get; set; }
    }
}