using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talleres.API.Repository;
using Talleres.Domain.DTOs;
using Talleres.Domain.Models.DTOs;
using Talleres.Domain.Models.DTOs.GetDTOs;
using Talleres.Domain.Models.DTOs.PostDTO;

namespace Talleres.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HorarioController : ControllerBase
    {
        protected ResponseDTO _responseDTO;
        protected ResponseVoidDTO _responseVoidDTO;
        private IHorarioRepository _horarioRepository;

        public HorarioController(IHorarioRepository horarioRepository)
        {
            _responseDTO =  new ResponseDTO();
            _responseVoidDTO = new ResponseVoidDTO();
            _horarioRepository = horarioRepository;
        }

        [HttpGet]
        public async Task<Object> Get()
        {
            IEnumerable<HorarioGetPostPutDTO> horarioDTO = null;
            try
            {
                horarioDTO = await _horarioRepository.GetHorarios();
                _responseDTO.Result = horarioDTO;
                _responseDTO.Success = true;
                _responseDTO.Message = "Horarios";
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
            HorarioGetPostPutDTO horarioDto = null;
            try
            {
                horarioDto = await _horarioRepository.GetHorarioById(id);
                _responseDTO.Result = horarioDto;
                _responseDTO.Success = true;
                _responseDTO.Message = "Libro";
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
        public async Task<Object> Post(HorarioPostDTO horarioPost)
        {
            HorarioPostDTO horario = horarioPost;
            try
            {
                bool flag = await _horarioRepository.PostHorario(horario);
                if (flag)
                {
                    _responseVoidDTO.Success = true;
                    _responseVoidDTO.Message = "Datos guardados. ¡Ha registrado un Nuevo Horario!";
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
        public async Task<Object> Put(HorarioGetPostPutDTO horarioPut)
        {
            HorarioGetPostPutDTO horario = horarioPut;
            try
            {
                bool flag = await _horarioRepository.PutHorario(horario);
                if (flag)
                {
                    _responseVoidDTO.Success = true;
                    _responseVoidDTO.Message = "Datos Actualizados";
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
                bool flag = await _horarioRepository.DeleteHorario(id);
                if (flag)
                {
                    _responseVoidDTO.Success = true;
                    _responseVoidDTO.Message = "Horario Eliminado";
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
