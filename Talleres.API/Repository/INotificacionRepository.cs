using Talleres.Domain.Models.DTOs;

namespace Talleres.API.Repository
{
    public interface INotificacionRepository
    {
        Task<List<NotificacionGetDTO>> GetNotificacionesByUsuario(int id);
        Task<bool> DeleteNotificacionesByUsuario(int id);
    }
}
