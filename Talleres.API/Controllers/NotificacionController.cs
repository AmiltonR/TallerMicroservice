using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talleres.API.Repository;
using Talleres.Domain.DTOs;
using Talleres.Domain.Models.DTOs;

namespace Talleres.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificacionController : ControllerBase
    {
        protected ResponseDTO _responseDTO;
        protected ResponseVoidDTO _responseVoidDTO;
        private INotificacionRepository _notificacionRepository;

        public NotificacionController(INotificacionRepository notificacionRepository)
        {
            _responseDTO = new ResponseDTO();
            _responseVoidDTO = new ResponseVoidDTO();
            _notificacionRepository = notificacionRepository;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<Object> Get(int id)
        {
            List<NotificacionGetDTO> notificaciones = null;
            try
            {
                notificaciones = await _notificacionRepository.GetNotificacionesByUsuario(id);
            }
            catch (Exception ex)
            {
                throw;
            }
            return Ok(notificaciones);
        }

        [HttpDelete("id")]
        [Route("{id}")]
        public async Task<Object> Delete(int id)
        {
            bool b = false;
            try
            {
                b = await _notificacionRepository.DeleteNotificacionesByUsuario(id);
                if (b)
                {
                    _responseDTO.Success = true;
                    _responseDTO.Message = "No tiene Notificaciones por leer!";
                }
                else
                {
                    _responseDTO.Message = "Error!";
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
