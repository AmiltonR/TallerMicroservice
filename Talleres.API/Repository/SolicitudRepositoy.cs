using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Talleres.Domain.Entities;
using Talleres.Domain.Models.DTOs;
using Talleres.Infrastructure;

namespace Talleres.API.Repository
{
    public class SolicitudRepositoy: ISolicitudRepository
    {
        private IMapper _mapper;
        private readonly TallerContext _db;

        public SolicitudRepositoy(IMapper mapper, TallerContext db)
        {
            _mapper = mapper;
            _db = db;
        }

        public async Task<bool> PostSolicitud(SolicitudPostDTO postSolicitud)
        {
            bool flag = false;
            try
            {
                List<Solicitud> solicitudes = null;
                solicitudes = await _db.Solicitudes.Where(s => s.IdUsuario == postSolicitud.IdUsuario).ToListAsync();

                if (solicitudes != null)
                {
                    foreach (var item in solicitudes)
                    {
                        _db.Solicitudes.Remove(item);
                    }
                }

                Solicitud solicitud = _mapper.Map<Solicitud>(postSolicitud);
                _db.Solicitudes.Add(solicitud);

                _db.SaveChanges();
                flag = true;
            }
            catch (Exception)
            {
                throw;
            }
            return flag;
        }

        public async Task<List<SolicitudGetDTO>> GetSolicitudes()
        {
            List<Solicitud> solicitudes = null;
            try
            {
                solicitudes = await _db.Solicitudes.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return _mapper.Map<List<SolicitudGetDTO>>(solicitudes);
        }

        public async Task<bool> DenegarSolicitud(int id)
        {
            bool flag = false;
            Solicitud sol = null;
            try
            {
                sol = await _db.Solicitudes.Where(s => s.Id == id).FirstOrDefaultAsync();

                if (sol!=null)
                {
                    _db.Solicitudes.Remove(sol);
                    await _db.SaveChangesAsync();
                    flag = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return flag;
        }

        public async Task<SolicitudGetDTO> GetSolicitudByUsuario(int id)
        {
            Solicitud sol = null;
            try
            {
                sol = await _db.Solicitudes.Where(s => s.IdUsuario == id).FirstOrDefaultAsync();
            }
            catch (Exception)
            {

                throw;
            }
            return _mapper.Map<SolicitudGetDTO>(sol);
        }
    }
}
