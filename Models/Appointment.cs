namespace FinalYearProject.Models
{
    public class Appointment
    {
                public int id { get; set; }
                public bool cancelled {get; set;} = false;
                public string CancelReason { get; set; } = "Sample";
                public DateTime dateTime { get; set; }
                public int mduration {get;set;}
                public string AppReason {get; set;} = "Sample";
                public int patient { get; set; }
                public int doctor {get; set;}
                public int treatment {get;set;}              

    }
}