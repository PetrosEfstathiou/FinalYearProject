using AutoMapper;
using FinalYearProject.Dtos.patient;
using FinalYearProject.Dtos.patient.Appointment;
using FinalYearProject.Dtos.patient.Xray;
using FinalYearProject.Dtos.patient.Doctor;
using FinalYearProject.Models;
using FinalYearProject.Dtos.patient.Treatment;

namespace FinalYearProject
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<patient,GetPatientDto>();
            CreateMap<AddPatientDto,patient>();
            CreateMap<Appointment,GetAppointmentDto>();
            CreateMap<AddAppointmentDto,Appointment>();
            CreateMap<Xray,XrayDto>();
            CreateMap<XrayDto,Xray>();
            CreateMap<Doctor,DoctorDto>();
            CreateMap<DoctorDto,Doctor>();
            CreateMap<Treatment,TreatmentDto>();
            CreateMap<TreatmentDto,Treatment>();            
        }
    }
}