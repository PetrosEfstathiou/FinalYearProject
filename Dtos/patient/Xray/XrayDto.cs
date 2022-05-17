namespace FinalYearProject.Dtos.patient.Xray
{
    public class XrayDto
    {
        public int id { get; set; }
        public int patient { get; set; } 
        public string xrname { get; set; }
        public byte[] xrimage { get; set; }
        public DateTime xrcreated {get; set;}
    }
}