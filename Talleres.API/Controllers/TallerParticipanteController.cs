using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talleres.API.Repository;
using Talleres.Domain.DTOs;
using Talleres.Domain.Models.DTOs;

namespace Talleres.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TallerParticipanteController : ControllerBase
    {
        protected ResponseDTO _response;
        private ITallerParticipanteRepository _tallerParticipanteRepository;

        public TallerParticipanteController(ITallerParticipanteRepository tallerParticipanteRepository)
        {
            _response = new ResponseDTO();
            _tallerParticipanteRepository = tallerParticipanteRepository;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<object> Get(int id)
        {
            IEnumerable<tallerParticipantesUsuariosDTO> tallerParticipante = null;
            try
            {
                tallerParticipante = await _tallerParticipanteRepository.GetTallerParticipantes(id);
            }
            catch (Exception ex)
            {
            }
            return Ok(tallerParticipante);
        }
    }
}
