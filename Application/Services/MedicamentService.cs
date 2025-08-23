using Holisticus2._0.Application.Interfaces;
using Holisticus2._0.Controllers;
using Holisticus2._0.Entities.Models;
using Holisticus2._0.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Holisticus2._0.Application.Services
{
    public class MedicamentService : IMedicamentService
    {
        private readonly AppDbContext _context;

        public MedicamentService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ActionResult<List<MedicamentModel>>> GetAllMedicamentAsync()
        {
            return await _context.Medicament.ToListAsync();
        }

        public Task<ActionResult<MedicamentModel>> AddMedicamentAsync(MedicamentModel medicament)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<MedicamentModel>> DeleteMedicamentAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<MedicamentModel>> EditMedicamentAsync(int id, string name)
        {
            throw new NotImplementedException();
        }



    }
}
