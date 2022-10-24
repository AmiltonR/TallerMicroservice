using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talleres.API.Repository;
using Talleres.Domain.DTOs;
using Talleres.Domain.Models.DTOs;
using Talleres.Domain.Models.DTOs.Publico;

namespace Talleres.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicoController : ControllerBase
    {
        protected ResponseDTO _responseDTO;
        protected ResponseVoidDTO _responseVoidDTO;
        private IPublicoRepository _publicoRepository;

        public PublicoController(IPublicoRepository publicoRepository)
        {
            _responseDTO = new ResponseDTO();
            _responseVoidDTO = new ResponseVoidDTO();
            _publicoRepository = publicoRepository;
        }

        [HttpGet]
        public async Task<Object> Get()
        {
            IEnumerable<PublicGetPutDTO> publicoDTO = null;
            try
            {
                publicoDTO = await _publicoRepository.GetPublicos();
                _responseDTO.Result = publicoDTO;
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
