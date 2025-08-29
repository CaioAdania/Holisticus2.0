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

        /// <summary>
        /// Busca os medicamentos.
        /// </summary>
        /// <returns>Retorna os medicamentos.</returns>
        [HttpGet]
        [Route("GetMedicaments")]
        public async Task<ActionResult<List<MedicamentModel>>> GetMedicament()
        {
            var medications = await _medicamentService.GetAllMedicamentAsync();
            return Ok(medications);
        }


        /// <summary>
        /// Adiciona medicamentos.
        /// </summary>
        /// <returns>Retorna o medicamento adicionado.</returns>
        [HttpPost]
        [Route("AddMedicament")]
        public async Task<ActionResult<MedicamentModel>> AddMedicament(MedicamentModel medicament)
        {
            try
            {
                var addMedicament = await _medicamentService.AddMedicamentAsync(medicament);

                if (addMedicament.Success == true)
                {
                    return Ok(addMedicament.Data);
                }

                return BadRequest(new
                {
                    Message = addMedicament.ErrorMessage,
                    ErrorType = addMedicament.ErrorType
                });
            }
            catch
            {
                return BadRequest("Erro no serviço.");
            }
        }

        //[HttpDelete]
        //[Route("DeleteMedicamet")]
        //public async Task<ActionResult<MedicamentModel>> DeleteMedicament(int id)
        //{
        //    var delete = _context.Medicament.Where(m => m.Id == id).FirstOrDefault();

        //    if(delete != null)
        //    {
        //        if(delete.StateCode == 1 && delete.IsDeleted == 0)
        //        {
        //            delete.StateCode = 0;
        //            delete.IsDeleted = 1;
        //            delete.DeletedBy = "Admin";

        //            _context.SaveChangesAsync();
        //        }
        //        else
        //        {
        //            _context.Medicament.Remove(delete);
        //            _context.SaveChangesAsync();
        //        }
        //    }
        //    else
        //    {
        //        return BadRequest("Medicamento não encontrado.");
        //    }


        //    return Ok(delete);
        //}

        //[HttpPost]
        //[Route("UpdateNameMedicamet")]
        //public async Task<ActionResult<MedicamentModel>> UpdateMedicament(int id, string name)
        //{
        //    var update = _context.Medicament.Where(m => m.Id == id).FirstOrDefault();

        //    if (update != null)
        //    {
        //        update.Name = name;
        //        _context.SaveChangesAsync();
        //    }
        //    else
        //    {
        //        return BadRequest("Não foi possivel atualizar o nome.");
        //    }

        //    return Ok(update);
        //}
    }
}
