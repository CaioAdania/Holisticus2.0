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
            var result = new OperationResult<MedicamentModel>();
            try
            {
                var delete = _context.Medicament.Where(m => m.Id == id).FirstOrDefault();

                if (delete == null)
                {
                    return result.Fail("Medicamento não localizado.", "404");
                }
                if (delete.Amount == 0)
                {
                    delete.StateCode = 0;
                    delete.IsDeleted = 1;
                    delete.DeletedBy = "admin";

                    _context.SaveChanges();
                    return result.Ok(delete);
                }

                return result.Fail("Não é possivel deletar um médicamento em estoque", "400");
            }
            catch
            {
                return result.Fail("Erro ao deletar medicamento","400");
            }
        }

        public async Task<OperationResult<MedicamentModel>> EditMedicamentAmountAsync(int id, int amount)
        {
            var result = new OperationResult<MedicamentModel>();
            try
            {
                var updateAmount = _context.Medicament.Where(m => m.Id == id).FirstOrDefault();

                if (updateAmount == null)
                {
                    return result.Fail("Medicamento não localizado.", "404");
                }
                if (updateAmount.Amount == 0)
                {
                    return result.Fail("Não existe estoque para esse medicamento.", "400");
                }

                updateAmount.Amount -= amount;

                _context.SaveChanges();
                return result.Ok(updateAmount);
            }
            catch
            {
                return result.Fail("Erro ao editar a quantidade.","400");
            }
        }
    }
}
