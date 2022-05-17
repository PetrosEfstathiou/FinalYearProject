using FinalYearProject.Models;
using FinalYearProject.Dtos.patient.Doctor;

namespace FinalYearProject.Services.patientService.DoctorService
{
    public interface IDoctorService
    {
         Task<ServiceResponse<List<DoctorDto>>> GetAllDoctors();
         Task<ServiceResponse<DoctorDto>> GetDoctorById (int id);
         Task<ServiceResponse<List<DoctorDto>>> AddDoctor(DoctorDto newDoctor);

         Task<ServiceResponse<DoctorDto>> UpdateDoctor(DoctorDto updatedDoctor);
    }
}