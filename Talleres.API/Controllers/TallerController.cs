using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talleres.API.Repository;
using Talleres.Domain.DTOs;
using Talleres.Domain.Models.DTOs;
using Talleres.Domain.Models.DTOs.GenreralDTOs;
using Talleres.Domain.Models.DTOs.GetDTOs;
using Talleres.Domain.Models.DTOs.PostDTO;

namespace Talleres.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TallerController : ControllerBase
    {
        protected ResponseDTO _responseDTO;
        protected ResponseVoidDTO _responseVoidDTO;
        private ITallerRepository _tallerRepository;

        public TallerController(ITallerRepository tallerRepository)
        {
            _responseDTO = new ResponseDTO();
            _responseVoidDTO = new ResponseVoidDTO();
            _tallerRepository = tallerRepository;
        }

        [HttpGet]
        public async Task<Object> Get()
        {
            IEnumerable<TallerDTO> tallerList = null;
            try
            {
                tallerList = await _tallerRepository.GetTalleres();
                _responseDTO.Result = tallerList;
                _responseDTO.Success = true;
                _responseDTO.Message = "Taller";
            }
            catch (Exception ex)
            {
                _responseDTO.Message = "Algo ocurió :(";
                _responseDTO.ErrorMessages = new List<string>() { ex.ToString() };
                throw;
            }
            return Ok(_responseDTO);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<Object> GetById(int id)
        {
            TallerDTO tallerDto = null;
            try
            {
                tallerDto = await _tallerRepository.GetTallerById(id);
                _responseDTO.Result = tallerDto;
                _responseDTO.Success = true;
                _responseDTO.Message = "Taller";
            }
            catch (Exception ex)
            {
                _responseDTO.Message = "Algo ocurió :(";
                _responseDTO.ErrorMessages = new List<string>() { ex.ToString() };
                throw;
            }
            return Ok(_responseDTO);
        }

        [HttpPost]
        public async Task<Object> Post(TallerPostDTO tallerPost)
        {
            TallerPostDTO taller = tallerPost;
            try
            {
                bool flag = await _tallerRepository.PostTaller(taller);
                if (flag)
                {
                    _responseVoidDTO.Success = true;
                    _responseVoidDTO.Message = "Datos guardados. ¡Ha registrado un Nuevo Taller!";
                }
                else
                {
                    _responseVoidDTO.Message = "Ya existe un Taller con ese título";
                }
            }
            catch (Exception ex)
            {
                _responseVoidDTO.Message = "Algo ocurrió :(";
                _responseVoidDTO.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return Ok(_responseVoidDTO);
        }

        [HttpPut]
        public async Task<Object> Put(TallerDTO tallerPut)
        {
            try
            {
                bool flag = await _tallerRepository.PutTaller(tallerPut);
                if (flag)
                {
                    _responseVoidDTO.Success = true;
                    _responseVoidDTO.Message = "Datos del Taller Actualizados";
                }
            }
            catch (Exception ex)
            {
                _responseVoidDTO.Message = "Ocurrió un Error :(";
                _responseVoidDTO.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return Ok(_responseVoidDTO);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<Object> Delete(int id)
        {
            try
            {
                bool flag = await _tallerRepository.DeleteTaller(id);
                if (flag)
                {
                    _responseVoidDTO.Success = true;
                    _responseVoidDTO.Message = "Taller Eliminado";
                }
                else
                {
                    _responseVoidDTO.Success = false;
                    _responseVoidDTO.Message = "No puede Eliminar el taller porque hay talleres programados";
                }
            }
            catch (Exception ex)
            {
                _responseVoidDTO.Message = "Ocurrió un Error :(";
                _responseVoidDTO.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return Ok(_responseVoidDTO);
        }
    }
}
