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


        [HttpGet]
        [Route("{id}")]
        public async Task<Object> GetById(int id)
        {
            PatrocinadorGetPutDTO patrocinadorDTO = null;
            try
            {
                patrocinadorDTO = await _patrocinadorRepository.GetPatrocinadorById(id);
                if (patrocinadorDTO!=null)
                {
                    _responseDTO.Result = patrocinadorDTO;
                    _responseDTO.Success = true;
                    _responseDTO.Message = "Patrocinador";
                }
                else
                {
                    _responseDTO.Message = "No existe el patrocinador";
                }
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
        public async Task<Object> Post(PatrocinadorPostDTO patrocinador)
        {
            bool flag = false;
            try
            {
                flag = await _patrocinadorRepository.PostPatrocinador(patrocinador);
                if (flag)
                {
                    _responseDTO.Success = true;
                    _responseDTO.Message = "Ha insertado un nuevo registro de patrocinador";
                }
                else
                {
                    _responseDTO.Message = "ocurrió un error";
                }
            }
            catch (Exception ex)
            {
                _responseDTO.Message = "Algo ocurrió :(";
                _responseDTO.ErrorMessages = new List<string>() { ex.ToString() };
                throw;
            }
            return Ok(_responseDTO);
        }

        [HttpPut]
        public async Task<Object> Put(PatrocinadorGetPutDTO patrocinador)
        {
            bool flag = false;
            try
            {
                flag = await _patrocinadorRepository.PutPatrocinador(patrocinador);
                if (flag)
                {
                    _responseDTO.Success = true;
                    _responseDTO.Message = "Ha actualizado el registro de patrocinador";
                }
                else
                {
                    _responseDTO.Message = "ocurrió un error";
                }
            }
            catch (Exception ex)
            {
                _responseDTO.Message = "Algo ocurrió :(";
                _responseDTO.ErrorMessages = new List<string>() { ex.ToString() };
                throw;
            }
            return Ok(_responseDTO);
        }

        [HttpDelete("{id}")]
       // [Route("{id}")]
        public async Task<Object> Delete(int id)
        {
            bool flag = false;
            try
            {
                flag = await _patrocinadorRepository.DeletePatrocinador(id);
                if (flag)
                {
                    _responseDTO.Success = true;
                    _responseDTO.Message = "Ha eliminado el registro de patrocinador";
                }
                else
                {
                    _responseDTO.Message = "No se puede eliminar el registro porque está vinculado con la programación de un taller";
                }
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
