using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Talleres.Domain.Entities;
using Talleres.Domain.Models.DTOs;
using Talleres.Infrastructure;

namespace Talleres.API.Repository
{
    public class TallerRepository : ITallerRepository
    {
        private readonly TallerContext _db;
        private IMapper _mapper;

        public TallerRepository(TallerContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<bool> DeleteTaller(int id)
        {
            bool flag = true;
            //Crear objeto taller con el ID
            Taller? taller = await _db.Talleres.FirstOrDefaultAsync(t => t.Id == id);

            //Comprobar que no hayan talleres con este id de taller
            //Traer la lista de talleres con ese Id
            IEnumerable<TallerProgramacion> tallerProgramacion = await _db.TallerProgramaciones.Where(t => t.IdTaller == taller.Id).ToListAsync();
            //Verificar respuesta
            if (tallerProgramacion.ToList().Count > 0)
                flag = false;
            else
            {
                _db.Talleres.Remove(taller);
                await _db.SaveChangesAsync();
            }
            return flag;
        }

        public async Task<IEnumerable<TallerDTO>> GetTalleres()
        {
            List<Taller> talleresList = await _db.Talleres.ToListAsync();
            return _mapper.Map<List<TallerDTO>>(talleresList);

        }

        //Get All Talleres
        public async Task<TallerDTO> GetTallerById(int id)
        {
            TallerDTO? tallerDto = null;
            try
            {
                Taller? taller = await _db.Talleres.FirstOrDefaultAsync(h => h.Id == id);
                tallerDto = _mapper.Map<TallerDTO>(taller);
            }
            catch (Exception)
            {
                throw;
            }
            return tallerDto;
        }

        public async Task<bool> PostTaller(TallerPostDTO tallerInsert)
        {
            bool flag = false;

            try
            {
                Taller tallerPost = _mapper.Map<TallerPostDTO, Taller>(tallerInsert);
                Taller? tallerVerificar = await _db.Talleres.Where(t => t.NombreTaller == tallerPost.NombreTaller).FirstOrDefaultAsync();

                if (tallerVerificar != null)
                {
                    return flag;
                }
                else
                {
                    _db.Talleres.Add(tallerPost);
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

        public async Task<bool> PutTaller(TallerDTO tallerUpdate)
        {
            bool flag = false;
            try
            {
                Taller tallerPut = _mapper.Map<TallerDTO, Taller>(tallerUpdate);
                _db.Talleres.Update(tallerPut);
                await _db.SaveChangesAsync();
                flag = true;
            }
            catch (Exception)
            {
                throw;
            }
            return flag;
        }

        public Task<bool> verifyExistence(string nombre)
        {

            throw new NotImplementedException();
        }
    }
}
