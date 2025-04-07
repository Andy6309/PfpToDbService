using System.Xml;
using System.Xml.Serialization;
using PfpToDbService;

namespace PfpReader.Models
{
    public class PfpParametric
    {
        [XmlElement]
        public PfpGeometryCheck GeometryCheck { get; set; } = PfpGeometryCheck.Unknown;
        [XmlElement]
        public PfpProgramCheck ProgramCheck { get; set; } = PfpProgramCheck.Unknown;
        [XmlElement("FeasibleForCAM")]
        public PfpFeasible FeasibleForCam { get; set; } = PfpFeasible.Unknown;
        [XmlElement]
        public PfpFeasible FeasibleForScript { get; set; } = PfpFeasible.Unknown;
        [XmlElement]
        public PfpFeasible FeasibleForBendExpress { get; set; } = PfpFeasible.Unknown;
        [XmlElement]
        public PfpFeasible FeasibleForAutometric { get; set; } = PfpFeasible.Unknown;
        [XmlElement]
        public PfpFeasible FeasibleForAutomatic { get; set; } = PfpFeasible.Unknown;
        [XmlElement]
        public PfpFeasible FeasibleForAutomaticNoGeo { get; set; } = PfpFeasible.Unknown;
        [XmlElement]
        public PfpFeasible FeasibleForAutometricNoGeo { get; set; } = PfpFeasible.Unknown;
        [XmlElement]
        public PfpParametricAlgorithm SuggestedAlgorithm { get; set; } = PfpParametricAlgorithm.None;
        [XmlElement]
        public PfpParametricAlgorithm SelectedAlgorithm { get; set; } = PfpParametricAlgorithm.None;
        [XmlElement]
        public PfpParametricAlgorithm UsedAlgorithm { get; set; } = PfpParametricAlgorithm.None;

        [XmlIgnore]
        public bool IsChildProgram { get; set; }

        [XmlElement(nameof(IsChildProgram))]
        public string IsChildProgramString
        {
            get => XmlConvert.ToString(IsChildProgram);
            set => IsChildProgram = value.ToBool();
        }

        [XmlElement]
        public string MotherProgramPath { get; set; } = string.Empty;

        [XmlElement("RESTGenerationString")]
        public string RestGenerationString { get; set; } = string.Empty;

        [XmlElement("CAMOptions ")]
        public PfpCamOptions CamOptions { get; set; } = new PfpCamOptions();
        [XmlElement]
        public PfpScriptOptions ScriptOptions { get; set; } = new PfpScriptOptions();
        [XmlElement]
        public PfpAutomaticOptions AutomaticOptions { get; set; } = new PfpAutomaticOptions();
        [XmlElement]
        public PfpAutomaticNoGeoOptions AutomaticNoGeoOptions { get; set; } = new PfpAutomaticNoGeoOptions();
        [XmlElement]
        public PfpAutometricOptions AutometricOptions { get; set; } = new PfpAutometricOptions();
        [XmlElement]
        public PfpAutometricNoGeoOptions AutometricNoGeoOptions { get; set; } = new PfpAutometricNoGeoOptions();
    }
}