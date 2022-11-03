using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talleres.API.Repository;
using Talleres.Domain.DTOs;
using Talleres.Domain.Models.DTOs;

namespace Talleres.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TallerProgramacionController : ControllerBase
    {
        protected ResponseDTO _responseDTO;
        protected ResponseVoidDTO _responseVoidDTO;
        private ITallerProgramacionRepository _tallerProgramacionRepository;

        public TallerProgramacionController(ITallerProgramacionRepository tallerRepository)
        {
            _responseDTO = new ResponseDTO();
            _responseVoidDTO = new ResponseVoidDTO();
            _tallerProgramacionRepository = tallerRepository;
        }

        [HttpGet]
        public async Task<Object> Get()
        {
            IEnumerable<TallerProgramacionGetDTO> tallerList = null;
            try
            {
                //Envío de Lista
                tallerList = await _tallerProgramacionRepository.GetTalleres();
                //_responseDTO.Result = tallerList;
                //_responseDTO.Success = true;
                //_responseDTO.Message = "Taller";
            }
            catch (Exception ex)
            {
                _responseDTO.Message = "Algo ocurrió :(";
                _responseDTO.ErrorMessages = new List<string>() { ex.ToString() };
                throw;
            }
            return Ok(tallerList);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<Object> GetById(int id)
        {
            TallerProgramacionGetDTO tallerDto = null;
            try
            {
                tallerDto = await _tallerProgramacionRepository.GetTallerById(id);
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
        public async Task<Object> Post(TallerProgramacionPostDTO tallerPost)
        {
            TallerProgramacionPostDTO taller = tallerPost;
            try
            {
                int flag = await _tallerProgramacionRepository.PostTaller(taller);
                if (flag == 1)
                {
                    _responseVoidDTO.Success = true;
                    _responseVoidDTO.Message = "Datos guardados. ¡Ha programado un Taller!";
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
        public async Task<Object> Put(TallerProgramacionPutDTO tallerPut)
        {
            try
            {
                bool flag = await _tallerProgramacionRepository.PutTaller(tallerPut);
                if (flag)
                {
                    _responseVoidDTO.Success = true;
                    _responseVoidDTO.Message = "Datos de la programacion del Taller Actualizados";
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
                bool flag = await _tallerProgramacionRepository.DeleteTaller(id);
                if (flag)
                {
                    _responseVoidDTO.Success = true;
                    _responseVoidDTO.Message = "Programación de Taller Eliminado";
                }
                else
                {
                    _responseVoidDTO.Success = false;
                    _responseVoidDTO.Message = "No puede Eliminar el taller porque está activo";
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
