using Holisticus2._0.Application.Interfaces;
using Holisticus2._0.Controllers;
using Holisticus2._0.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace Holisticus2._0.Application.Services
{
    public class MedicamentService : IMedicamentService
    {
        private readonly AppDbContext _context;

        public MedicamentService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ActionResult<List<MedicamentController>>> GetAllMedicamentAsync()
        {
            var medications = _context.Medicament.ToList();

            throw new NotImplementedException();
        }

        public Task<ActionResult<MedicamentController>> AddMedicamentAsync(MedicamentController medicament)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<MedicamentController>> DeleteMedicamentAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<MedicamentController>> EditMedicamentAsync(int id, string name)
        {
            throw new NotImplementedException();
        }



    }
}
