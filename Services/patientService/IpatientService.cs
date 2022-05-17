using System.Collections.Generic;
using FinalYearProject.Models;
using System.Threading.Tasks;
using FinalYearProject.Dtos.patient;

namespace FinalYearProject.Services.patientService
{
    public interface IpatientService
    {
         Task<ServiceResponse<List<GetPatientDto>>> GetAllpatients();
         Task<ServiceResponse<GetPatientDto>> GetpatientById (int id);

         Task<ServiceResponse<GetPatientDto>> GetpatientByTel (int telnum);
         Task<ServiceResponse<List<GetPatientDto>>> AddPatient(AddPatientDto newPatient);

         Task<ServiceResponse<GetPatientDto>> UpdatePatient(UpdatePatientDto updatedPatient);

         Task<ServiceResponse<List<GetPatientDto>>> DeletePatient(int id);
    }
}