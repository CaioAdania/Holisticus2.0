using Holisticus2._0.Application.Interfaces;
using Holisticus2._0.Entities.Models;
using Holisticus2._0.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Holisticus2._0.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MedicamentController : ControllerBase
    {
        private readonly IMedicamentService _medicamentService;

        public MedicamentController(IMedicamentService medicamentService)
        {
            _medicamentService = medicamentService;
        }

        [HttpGet]
        [Route("SearchMedicaments")]
        public ActionResult<List<Medicament>> GetMedicament()
        {
            var medications = _context.Medicament.ToList();
            return Ok(Medications);
        }

        [HttpPost]
        [Route("AddMedicament")]
        public ActionResult<Medicament> AddMedicament(Medicament medicament)
        {
            _context.Medicament.Add(medicament);
            _context.SaveChangesAsync();

            return Ok(medicament);
        }

        [HttpDelete]
        [Route("DeleteMedicamet")]
        public ActionResult<Medicament> DeleteMedicament(int id)
        {
            var delete = _context.Medicament.Where(m => m.Id == id).FirstOrDefault();
            
            if(delete != null)
            {
                if(delete.StateCode == 1 && delete.IsDeleted == 0)
                {
                    delete.StateCode = 0;
                    delete.IsDeleted = 1;
                    delete.DeletedBy = "Admin";

                    _context.SaveChangesAsync();
                }
                else
                {
                    _context.Medicament.Remove(delete);
                    _context.SaveChangesAsync();
                }
            }
            else
            {
                return BadRequest("Medicamento não encontrado.");
            }


            return Ok(delete);
        }

        [HttpPost]
        [Route("UpdateNameMedicamet")]
        public ActionResult<Medicament> UpdateMedicament(int id, string name)
        {
            var update = _context.Medicament.Where(m => m.Id == id).FirstOrDefault();

            if (update != null)
            {
                update.Name = name;
                _context.SaveChangesAsync();
            }
            else
            {
                return BadRequest("Não foi possivel atualizar o nome.");
            }

            return Ok(update);
        }
    }
}
