using System.Collections.Generic;
using System.Xml.Serialization;

namespace PfpReader.Models
{
    /// <summary>
    /// Contour class
    /// </summary>
    public class PfpContour
    {

        [XmlElement(Type = typeof(PfpLineContour), ElementName = "Line")]
        [XmlElement(Type = typeof(PfpArcContour), ElementName = "Arc")]
        [XmlElement(Type = typeof(PfpCircleContour), ElementName = "Circle")]
        public List<PfpContourElement> Elements = new List<PfpContourElement>();

        [XmlAttribute("ContourID")]
        public string ContourId { get; set; }

        [XmlAttribute]
        public PfpType Type { get; set; }

        [XmlAttribute]
        public PfpMethod Method { get; set; }

        [XmlAttribute]
        public PfpSide Side { get; set; }

        [XmlAttribute]
        public PfpBendType BendType { get; set; }

        [XmlAttribute]
        public double BendAngle { get; set; }

        [XmlAttribute]
        public double BendRadius { get; set; }

        [XmlAttribute]
        public double Springback { get; set; }

        [XmlAttribute]
        public double BendDeduction { get; set; }

        [XmlAttribute]
        public double PreBendAngle { get; set; }

        [XmlAttribute]
        public PfpStepBendMode StepBendMode { get; set; }

        [XmlAttribute]
        public int StepNumber { get; set; }
    }
}