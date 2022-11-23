using Talleres.Domain.Models.DTOs;

namespace Talleres.API.Repository
{
    public class NotificacionesRepository : INotificacionRepository
    {
        public Task<bool> DeleteNotificacionesByUsuario(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<NotificacionGetDTO>> GetNotificacionesByUsuario(int id)
        {
            throw new NotImplementedException();
        }
    }
}
