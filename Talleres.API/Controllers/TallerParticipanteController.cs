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
            tallerParticipantesUsuariosResponseDTO tallerParticipante = null;
            try
            {
                tallerParticipante = await _tallerParticipanteRepository.GetTallerParticipantes(id);
            }
            catch (Exception ex)
            {
            }
            return Ok(tallerParticipante);
        }

        [HttpGet]
        [Route("noinscritos/{id}")]
        public async Task<object> GetNoInscritos(int id)
        {
            List<tallerParticipantesUsuariosDTO> tallerParticipante = null;
            try
            {
                tallerParticipante = await _tallerParticipanteRepository.GetTallerParticipantesNoIns(id);
            }
            catch (Exception ex)
            {
            }
            return Ok(tallerParticipante);
        }

        [HttpPost]
        [Route("inscribir")]
        public async Task<object> Post(TallerParticipantePostDTO tallerParticipantes)
        {
            bool flag = false;
            try
            {
                flag = await _tallerParticipanteRepository.PostParticipantes(tallerParticipantes);
                if (flag)
                {
                    _response.Success = true;
                    _response.Message = "Participantes Inscritos";
                }
            }
            catch (Exception ex)
            {
                _response.Message = "Hubo un error";
            }
            return Ok(_response);
        }

        [HttpPost]
        [Route("inscripcion/{id}")]
        public async Task<object> PostInscripcionByBibliotecaria(int id)
        {
            bool flag = false;
            try
            {
                flag = await _tallerParticipanteRepository.PostParticipantesAceptaSolicitud(id);
                if (flag)
                {
                    _response.Success = true;
                    _response.Message = "Participante Inscrito";
                }
                else
                {
                    _response.Message = "Ocurrió un error al incribir al estudiante. Estudiante no inscrito!";
                }
            }
            catch (Exception ex)
            {
                _response.Message = "Hubo un error";
            }
            return Ok(_response);
        }
        //Delete participante
        [HttpDelete]
        public async Task<object> DeleteParticipante(DeleteParticipanteDTO participante)
        {
            bool flag = false;
            try
            {
                flag = await _tallerParticipanteRepository.DeleteParticipante(participante);
                if (flag)
                {
                    _response.Success = true;
                    _response.Message = "El participante ya no está inscrito";
                }
                else
                {
                    _response.Message = "Ocurrió un error!";
                }
            }
            catch (Exception ex)
            {
                _response.Message = "Hubo un error";
            }
            return Ok(_response);
        }
    }
}
