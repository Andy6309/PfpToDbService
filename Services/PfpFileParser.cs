using PfpToDbService.Models;
using System.Xml.Serialization;
using Microsoft.Extensions.Logging;
using PfpReader.Models;

namespace PfpToDbService.Services
{
    public class PfpFileParser
    {
        private readonly ILogger<PfpFileParser> _logger;

        public PfpFileParser(ILogger<PfpFileParser> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Parses the .pfp file (XML) into structured data used to store in the database.
        /// </summary>
        /// <param name="filePath">Path to the .pfp file.</param>
        /// <returns>A ParsedPfpData object with relevant data.</returns>
        public ParsedPfpData ParsePfpFile(string filePath)
        {
            _logger.LogDebug($"PfpFileParser - Parsing file: {filePath}");
            var bytes = File.ReadAllBytes(filePath);
            PfpRoot pfpData = new PfpRoot();
            using (var stream = new MemoryStream(bytes))
            {
                try
                {

                    var serializer = new XmlSerializer(typeof(PfpRoot));
                    serializer.UnknownNode += (sender, e) =>
                    {
                        // e.Name is the name of the unknown element or node
                        // e.Text has its value, etc.
                        // Here you can log or just ignore it
                    };

                    serializer.UnknownAttribute += (sender, e) =>
                    {
                        // e.Attr.Name is the name of the unknown attribute
                        // e.Attr.Value is its value
                        // Here you can log or just ignore it
                    };
                    pfpData = (PfpRoot)serializer.Deserialize(stream);


                }
                catch (Exception e)
                {
                    _logger.LogError(e, $"Could not parse file: {filePath}");
                }
            }

            if (pfpData == null || pfpData.Tooling == null || pfpData.Header == null || pfpData.Nc == null)
            {

                return new ParsedPfpData();
            }

            var parsedData = new ParsedPfpData
            {
                PartName = pfpData.Header.PieceName,
                BendingMachineName = pfpData.Tooling.CellName,

                UBC = IsUbc(pfpData.Tooling.ManipulatorTools),
                ASP = IsAsp(pfpData.Tooling.BenderTools.AspTools),
                AUT = IsAut(pfpData.Tooling.BenderTools.AutTools),

                Tested = IsTested(pfpData.Nc.Settings?.Settings ?? [])
            };
            return parsedData;
        }

        private bool IsTested(List<PfpSettingParameter> settings)
        {
            if (settings == null)
            {
                return false;
            }

            var testedElement = settings.FirstOrDefault(x => x.Name.Equals("Tested", StringComparison.InvariantCultureIgnoreCase));
            return testedElement != null && testedElement.Value.Equals("true", StringComparison.InvariantCultureIgnoreCase);
        }

        private bool IsAut(PfpToolingElements autTools)
        {
            return autTools?.Segments?.Any() ?? false;

        }

        private bool IsAsp(PfpAspTools aspTools)
        {
            if (aspTools == null)
            {
                return false;
            }

            return (aspTools.BracketsCouplesLeft?.UpperBlades?.Segments?.Count > 0 ||
                    aspTools.BracketsCouplesLeft?.LowerBlades?.Segments?.Count > 0 ||
                    aspTools.BracketsCouplesRight?.UpperBlades?.Segments?.Count > 0 ||
                    aspTools.BracketsCouplesRight?.LowerBlades?.Segments?.Count > 0);
        }

        private bool IsUbc(PfpManipulatorTools manipulatorTools)
        {
            return manipulatorTools?.Clamp?.Name?.Contains("UBC", StringComparison.CurrentCultureIgnoreCase) ?? false;
        }


    }
}
