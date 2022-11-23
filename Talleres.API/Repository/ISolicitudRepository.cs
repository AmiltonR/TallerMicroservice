using Talleres.Domain.Models.DTOs;

namespace Talleres.API.Repository
{
    public interface ISolicitudRepository
    {
        Task<bool> PostSolicitud(SolicitudPostDTO postSolicitud);
        Task<List<SolicitudGetDTO>> GetSolicitudes();
        Task<bool> DenegarSolicitud(int id);
        Task<SolicitudGetDTO> GetSolicitudByUsuario(int id);
    }
}
