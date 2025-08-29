using Holisticus2._0.Controllers;
using Holisticus2._0.Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Holisticus2._0.Entities.Response;

namespace Holisticus2._0.Application.Interfaces
{
    public interface IMedicamentService
    {
        Task<ActionResult<List<MedicamentModel>>> GetAllMedicamentAsync();
        Task<OperationResult<MedicamentModel>> AddMedicamentAsync(MedicamentModel medicament);
        Task<OperationResult<MedicamentModel>> DeleteMedicamentAsync(int id);
        Task<OperationResult<MedicamentModel>> EditMedicamentAsync(int id, string name);
    }
}
