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
                _responseDTO.Message = "Públicos";
            }
            catch (Exception ex)
            {
                _responseDTO.Message = "Algo ocurrió :(";
                _responseDTO.ErrorMessages = new List<string>() { ex.ToString() };
                throw;
            }
            return Ok(_responseDTO);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<Object> GetById(int id)
        {
            PublicGetPutDTO publicoDTO = null;
            try
            {
                publicoDTO = await _publicoRepository.GetPublicoById(id);
                _responseDTO.Result = publicoDTO;
                _responseDTO.Success = true;
                _responseDTO.Message = "Público";
            }
            catch (Exception ex)
            {
                _responseDTO.Message = "Algo ocurrió :(";
                _responseDTO.ErrorMessages = new List<string>() { ex.ToString() };
                throw;
            }
            return Ok(_responseDTO);
        }

        [HttpPost]
        public async Task<Object> Post(PublicoPostDTO publico)
        {
            bool flag;
            try
            {
                flag = await _publicoRepository.PostPublico(publico);
                _responseVoidDTO.Success = true;
                _responseVoidDTO.Message = "¡Ha registrado un nuevo Público!";
            }
            catch (Exception ex)
            {
                _responseVoidDTO.Message = "Algo ocurrió :(";
                _responseVoidDTO.ErrorMessages = new List<string>() { ex.ToString() };
                throw;
            }
            return Ok(_responseVoidDTO);
        }

        [HttpPut]
        public async Task<Object> Put(PublicGetPutDTO publico)
        {
            bool flag;
            try
            {
                flag = await _publicoRepository.PutPublico(publico);
                _responseVoidDTO.Success = true;
                _responseVoidDTO.Message = "¡Ha actualizado el registro!";
            }
            catch (Exception ex)
            {
                _responseVoidDTO.Message = "Algo ocurrió :(";
                _responseVoidDTO.ErrorMessages = new List<string>() { ex.ToString() };
                throw;
            }
            return Ok(_responseVoidDTO);
        }
    }
}
