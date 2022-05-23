using AutoMapper;
using FinalYearProject.Dtos.patient;
using FinalYearProject.Dtos.patient.Appointment;
using FinalYearProject.Dtos.patient.Xray;
using FinalYearProject.Dtos.patient.Doctor;
using FinalYearProject.Models;
using FinalYearProject.Dtos.patient.Treatment;
using FinalYearProject.Dtos.patient.TreatmentCost;

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
            CreateMap<Xray,AddXrayDto>();
            CreateMap<AddXrayDto,Xray>();
            CreateMap<Doctor,DoctorDto>();
            CreateMap<DoctorDto,Doctor>();
            CreateMap<Treatment,TreatmentDto>();
            CreateMap<TreatmentDto,Treatment>();
            CreateMap<AddTreatmentDto,Treatment>();
            CreateMap<AddDoctorDto,Doctor>();
            CreateMap<TreatmentCostDto,TreatmentCost>();
            CreateMap<TreatmentCost,TreatmentCostDto>();
                        
        }
    }
}