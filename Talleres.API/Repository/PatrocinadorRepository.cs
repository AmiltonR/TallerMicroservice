using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Talleres.Domain.Entities;
using Talleres.Domain.Models.DTOs.Patrocinador;
using Talleres.Domain.Models.DTOs.Publico;
using Talleres.Infrastructure;

namespace Talleres.API.Repository
{
    public class PatrocinadorRepository : IPatrocinadorRepository
    {
        private readonly TallerContext _db;
        private IMapper _mapper;

        public PatrocinadorRepository(TallerContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public Task<bool> DeletePatrocinador(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PatrocinadorGetPutDTO>> GetPatrocinadores()
        {
            List<Patrocinador> patrocinadorList = await _db.Patrocinadores.ToListAsync();
            return _mapper.Map<List<PatrocinadorGetPutDTO>>(patrocinadorList);
        }

        public async Task<PatrocinadorGetPutDTO> GetPatrocinadorById(int id)
        {
            Patrocinador patrocinador = await _db.Patrocinadores.Where(p => p.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<PatrocinadorGetPutDTO>(patrocinador);
        }

        public async Task<bool> PostPatrocinador(PatrocinadorPostDTO patrocinadorInsert)
        {
            bool flag = false;
            try
            {
                Patrocinador patrocinador = _mapper.Map<PatrocinadorPostDTO, Patrocinador>(patrocinadorInsert);
                _db.Patrocinadores.Add(patrocinador);
                await _db.SaveChangesAsync();
                flag = true;
            }
            catch (Exception)
            {

                throw;
            }
            return flag;
        }

        public async Task<bool> PutPatrocinador(PatrocinadorGetPutDTO patrocinadorUpdate)
        {
            bool flag = false;
            try
            {
                Patrocinador patrocinador = _mapper.Map<PatrocinadorGetPutDTO, Patrocinador>(patrocinadorUpdate);
                _db.Patrocinadores.Update(patrocinador);
                await _db.SaveChangesAsync();
                flag = true;
            }
            catch (Exception)
            {

                throw;
            }
            return false;   
        }
    }
}
