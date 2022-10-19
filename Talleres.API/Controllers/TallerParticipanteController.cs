using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talleres.API.Repository;
using Talleres.Domain.DTOs;

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
        public async Task<object> Get()
        {
            IEnumerable<TallerParticipanteGetDTO> tallerParticipante = null;
            try
            {
                tallerParticipante = await _tallerParticipanteRepository.GetTallerParticipantes();
                _response.Result = tallerParticipante;
            }
            catch (Exception ex)
            {
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return Ok(tallerParticipante);
        }
    }
}
