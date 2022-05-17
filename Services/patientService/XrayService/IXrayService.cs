
using FinalYearProject.Dtos.patient.Xray;
using FinalYearProject.Models;

namespace FinalYearProject.Services.patientService
{
    public interface IXrayService
    {
         Task<ServiceResponse<int>> AddXray (AddXrayDto newXray);
         Task<ServiceResponse<int>> DeleteXray(int id);
         Task<ServiceResponse<List<XrayDto>>> GetXray(int patientid);
         
    }
}