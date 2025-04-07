using System.Xml.Serialization;

namespace PfpReader.Models
{
    public class PfpBend
    {
        [XmlAttribute]
        public string Name = string.Empty;
        [XmlAttribute]
        public double EndAngle = double.NaN;
        [XmlAttribute]
        public bool Running
        {
            get =>
                _Running.HasValue && _Running.Value;
            set => _Running = value;
        }

        #region XmlIgnore
        [XmlIgnore]
        public bool EndAngleSpecified => !double.IsNaN(EndAngle);

        [XmlIgnore]
        public bool RunningSpecified => _Running.HasValue;

        private bool? _Running;
        #endregion
    }
}