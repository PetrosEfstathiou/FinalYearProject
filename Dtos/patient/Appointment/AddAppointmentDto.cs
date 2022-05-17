namespace FinalYearProject.Dtos.patient.Appointment
{
    public class AddAppointmentDto

    {
        public DateTime dateTime { get; set; }
        public int mduration {get;set;}
        public string AppReason {get; set;} = "Sample";
        public int patient { get; set; }
        public int doctor { get; set; }
        public int treatment { get; set; }
        
    }
}