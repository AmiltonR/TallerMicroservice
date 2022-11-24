using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Talleres.Domain.Entities;
using Talleres.Domain.Models.DTOs;
using Talleres.Infrastructure;

namespace Talleres.API.Repository
{
    public class NotificacionesRepository : INotificacionRepository
    {
        private IMapper _mapper;
        private readonly TallerContext _db;

        public NotificacionesRepository(IMapper mapper, TallerContext db)
        {
            _mapper = mapper;
            _db = db;
        }

        public async Task<bool> DeleteNotificacionesByUsuario(int id)
        {
            bool flag = false;
            try
            {
                List<Notificacion> notificacion = await _db.Notificaciones.Where(n => n.IdUsuario == id).ToListAsync();

                foreach (var item in notificacion)
                {
                    _db.Notificaciones.Remove(item);
                }
                await _db.SaveChangesAsync();
                flag = true;
            }
            catch (Exception)
            {

                throw;
            }
            return flag;
        }

        public async Task<List<NotificacionGetDTO>> GetNotificacionesByUsuario(int id)
        {
            List<Notificacion> notif = null;
            try
            {
                notif = await _db.Notificaciones.Where(n => n.IdUsuario == id).ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
            return _mapper.Map<List<NotificacionGetDTO>>(notif);
            
        }
    }
}
