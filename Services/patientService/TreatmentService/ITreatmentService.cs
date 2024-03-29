using FinalYearProject.Dtos.patient.Treatment;
using FinalYearProject.Models;

namespace FinalYearProject.Services.patientService.TreatmentService
{
    public interface ITreatmentService
    {
        Task<ServiceResponse<TreatmentDto>> GetTreatment(int tid);
        Task<ServiceResponse<int>> AddTreatment (AddTreatmentDto newTreatment);
        Task <ServiceResponse<int>> EditTreatment (TreatmentDto updatedTreatment);
        Task<ServiceResponse<TreatmentDto>> GetTreatmentbyAppID(int id);
        Task<ServiceResponse<List<TreatmentDto>>> GetTreatmentbyPatientID (int pid);


    }
}