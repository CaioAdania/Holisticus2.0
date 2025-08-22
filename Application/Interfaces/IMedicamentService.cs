using Holisticus2._0.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Holisticus2._0.Application.Interfaces
{
    public interface IMedicamentService
    {
        Task<ActionResult<List<MedicamentController>>> GetAllMedicamentAsync();
        Task<ActionResult<MedicamentController>> AddMedicamentAsync(MedicamentController medicament);
        Task<ActionResult<MedicamentController>> DeleteMedicamentAsync(int id);
        Task<ActionResult<MedicamentController>> EditMedicamentAsync(int id, string name);
    }
}
