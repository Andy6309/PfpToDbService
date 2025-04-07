namespace PfpToDbService.Models
{
    public class ParsedPfpData
    {
        public string PartName { get; set; } = string.Empty;
        public string BendingMachineName { get; set; } = string.Empty;
       
        public bool UBC { get; set; }
        public bool ASP { get; set; }
        public bool AUT { get; set; }
        public bool Tested { get; set; }

        public bool PanelBendable { get; set; }


    }
}
