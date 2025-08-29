using Holisticus2._0.Application.Interfaces;
using Holisticus2._0.Controllers;
using Holisticus2._0.Entities.Models;
using Holisticus2._0.Entities.Response;
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

        public async Task<OperationResult<MedicamentModel>> AddMedicamentAsync(MedicamentModel medicament)
        {
            var result = new OperationResult<MedicamentModel>();

            try
            {
                var exist = _context.Medicament.Where(m => m.Name == medicament.Name).FirstOrDefault();

                if(exist != null)
                {
                    return result.Fail("Medicamento já existente", "400");
                }

                _context.Add(medicament);
                _context.SaveChanges();

                return result.Ok(medicament);

            }
            catch
            {
                return result.Fail("Erro ao adicionar medicamento", "400");
            }
        }

        public async Task<OperationResult<MedicamentModel>> DeleteMedicamentAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<OperationResult<MedicamentModel>> EditMedicamentAsync(int id, string name)
        {
            throw new NotImplementedException();
        }



    }
}
