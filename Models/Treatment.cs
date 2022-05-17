namespace FinalYearProject.Models
{
    public class Treatment
    {
        public int id { get; set; }
        public int appointment { get; set; }
        public byte[] timage { get; set; }
        public string treatment { get ; set; } = "Test";
        public int cost {get;set;}
        public int patient {get;set;}
    }
}