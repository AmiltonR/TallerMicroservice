using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Talleres.Domain.Entities;
using Talleres.Domain.Models.DTOs;
using Talleres.Domain.Models.DTOs.Publico;
using Talleres.Infrastructure;

namespace Talleres.API.Repository
{
    public class PublicoRepository : IPublicoRepository
    {
        private readonly TallerContext _db;
        private IMapper _mapper;

        public PublicoRepository(TallerContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<IEnumerable<PublicGetPutDTO>> GetPublicos()
        {
            List<Publico> publicoList = await _db.Publicos.ToListAsync();
            return _mapper.Map<List<PublicGetPutDTO>>(publicoList);
        }
        public async Task<PublicGetPutDTO> GetPublicoById(int id)
        {
            Publico publico = await _db.Publicos.Where(p => p.Id == id).FirstOrDefaultAsync();
            PublicGetPutDTO publicoGet = _mapper.Map<PublicGetPutDTO>(publico);
            return publicoGet;
        }
        public async Task<bool> PostPublico(PublicoPostDTO publicoInsert)
        {
            bool flag = false;
            try
            {
                Publico publico = _mapper.Map<PublicoPostDTO, Publico>(publicoInsert);
                _db.Publicos.Add(publico);
                await _db.SaveChangesAsync();
                flag = true;
            }
            catch (Exception)
            {

                throw;
            }
            return flag;
        }

        public async Task<bool> PutPublico(PublicGetPutDTO publicoUpdate)
        {
            bool flag = false;
            try
            {
                Publico publicoPut = _mapper.Map<PublicGetPutDTO, Publico>(publicoUpdate);
                _db.Publicos.Update(publicoPut);
                await _db.SaveChangesAsync();
                flag = true;
            }
            catch (Exception)
            {

                throw;
            }
            return flag;
        }
        public Task<bool> DeletePublico(int id)
        {
            throw new NotImplementedException();
        }
    }
}
