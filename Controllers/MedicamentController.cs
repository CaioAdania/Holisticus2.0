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

        [HttpDelete]
        [Route("{id}/DeleteMedicamet")]
        public async Task<ActionResult<MedicamentModel>> DeleteMedicament(int id)
        {
            try
            {
                var idDeleted = await _medicamentService.DeleteMedicamentAsync(id);

                if(idDeleted.Success == true)
                {
                    return Ok(idDeleted.Data);
                }

                return BadRequest(new
                {
                    Message = idDeleted.ErrorMessage,
                    ErrorType = idDeleted.ErrorType
                });
            }
            catch
            {
                return BadRequest("Erro no serviço.");
            }
        }

        [HttpPost]
        [Route("{id}/{amount}/UpdateAmoutMedicamet")]
        public async Task<ActionResult<MedicamentModel>> UpdateAmoutMedicament(int id, int amount)
        {
            try
            {
                var updateAmout = await _medicamentService.EditMedicamentAmountAsync(id, amount);

                if(updateAmout.Success == true)
                {
                    return Ok(updateAmout.Data);
                }

                return BadRequest(new
                {
                    Message = updateAmout.ErrorMessage,
                    ErrorType = updateAmout.ErrorType
                });
            }
            catch
            {
                return BadRequest("Erro no serviço.");
            }
        }
    }
}
