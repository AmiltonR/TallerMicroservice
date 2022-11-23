using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talleres.API.Repository;
using Talleres.Domain.DTOs;
using Talleres.Domain.Models.DTOs;

namespace Talleres.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitudController : ControllerBase
    {
        protected ResponseDTO _responseDTO;
        protected ResponseVoidDTO _responseVoidDTO;
        private ISolicitudRepository _solicitudRepository;

        public SolicitudController(ISolicitudRepository solicitudRepository)
        {
            _responseDTO = new ResponseDTO();
            _responseVoidDTO = new ResponseVoidDTO();
            _solicitudRepository = solicitudRepository;
        }

        [HttpGet]
        public async Task<Object> Get()
        {
            IEnumerable<SolicitudGetDTO> solicitud = null;
            try
            {
                solicitud = await _solicitudRepository.GetSolicitudes();
            }
            catch (Exception ex)
            {
                throw;
            }
            return Ok(solicitud);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<Object> GetById(int id)
        {
            SolicitudGetDTO solicitud = null;
            try
            {
                solicitud = await _solicitudRepository.GetSolicitudByUsuario(id);
                if (solicitud != null)
                {
                    _responseDTO.Success = true;
                    _responseDTO.Result= solicitud;
                    _responseDTO.Message = "Solicitud";
                }
                else
                {
                    _responseDTO.Message = "No se encontró solicitud";
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return Ok(_responseDTO);
        }

        [HttpPost]
        public async Task<Object> Post(SolicitudPostDTO solicitud)
        {
            bool b = false;
            try
            {
                b = await _solicitudRepository.PostSolicitud(solicitud);
                if (b)
                {
                    _responseDTO.Success = true;
                    _responseDTO.Message = "Solicitud de inscripción realizada con éxito!";
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

        [HttpDelete("id")]
        [Route("{id}")]
        public async Task<Object> Delete(int id)
        {
            bool b = false;
            try
            {
                b = await _solicitudRepository.DenegarSolicitud(id);
                if (b)
                {
                    _responseDTO.Success = true;
                    _responseDTO.Message = "Solicitud Denegada!";
                }
                else
                {
                    _responseDTO.Message = "Solicitud no existe!";
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
