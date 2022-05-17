using FinalYearProject.Dtos.patient.Treatment;
using FinalYearProject.Models;

namespace FinalYearProject.Services.patientService.TreatmentService
{
    public interface ITreatmentService
    {
        Task<ServiceResponse<List<TreatmentDto>>> GetTreatment(int pid);
        Task<ServiceResponse<int>> AddTreatment (TreatmentDto newTreatment);
        Task <ServiceResponse<int>> EditTreatment (TreatmentDto updatedTreatment);

    }
}