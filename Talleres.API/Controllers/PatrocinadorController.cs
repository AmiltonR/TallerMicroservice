using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talleres.API.Repository;
using Talleres.Domain.DTOs;
using Talleres.Domain.Models.DTOs.Publico;
using Talleres.Domain.Models.DTOs;
using Talleres.Domain.Models.DTOs.Patrocinador;

namespace Talleres.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatrocinadorController : ControllerBase
    {
        protected ResponseDTO _responseDTO;
        protected ResponseVoidDTO _responseVoidDTO;
        private IPatrocinadorRepository _patrocinadorRepository;

        public PatrocinadorController(IPatrocinadorRepository patrocinadorRepository)
        {
            _responseDTO = new ResponseDTO();
            _responseVoidDTO = new ResponseVoidDTO();
            _patrocinadorRepository = patrocinadorRepository;
        }

        [HttpGet]
        public async Task<Object> Get()
        {
            IEnumerable<PatrocinadorGetPutDTO> patrocinadorDTO = null;
            try
            {
                patrocinadorDTO = await _patrocinadorRepository.GetPatrocinadores();
                _responseDTO.Result = patrocinadorDTO;
                _responseDTO.Success = true;
                _responseDTO.Message = "Publicos";
            }
            catch (Exception ex)
            {
                _responseDTO.Message = "Algo ocurrió :(";
                _responseDTO.ErrorMessages = new List<string>() { ex.ToString() };
                throw;
            }
            return Ok(_responseDTO);
        }
    }
}
