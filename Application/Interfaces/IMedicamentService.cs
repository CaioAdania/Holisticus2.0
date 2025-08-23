using Holisticus2._0.Controllers;
using Holisticus2._0.Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace Holisticus2._0.Application.Interfaces
{
    public interface IMedicamentService
    {
        Task<ActionResult<List<MedicamentModel>>> GetAllMedicamentAsync();
        Task<ActionResult<MedicamentModel>> AddMedicamentAsync(MedicamentModel medicament);
        Task<ActionResult<MedicamentModel>> DeleteMedicamentAsync(int id);
        Task<ActionResult<MedicamentModel>> EditMedicamentAsync(int id, string name);
    }
}
