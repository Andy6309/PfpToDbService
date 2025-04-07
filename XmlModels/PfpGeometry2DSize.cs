using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace PfpReader.Models
{
    public class PfpGeometry2DSize
    {
        [XmlAttribute]
        public double X { get; set; }

        [XmlAttribute]
        public double Y { get; set; }

        [XmlAttribute]
        public double AreaNet { get; set; }

        [XmlAttribute] 
        public string CheckSum { get; set; } = string.Empty;
    }
}