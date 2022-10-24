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
        public Task<bool> DeletePublico(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PublicGetPutDTO> GetPublicoById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PublicGetPutDTO>> GetPublicos()
        {
            List<Publico> publicoList = await _db.Publicos.ToListAsync();
            return _mapper.Map<List<PublicGetPutDTO>>(publicoList);
        }

        public Task<bool> PostPublico(PublicoPostDTO publicoInsert)
        {
            throw new NotImplementedException();
        }

        public Task<bool> PutPublico(PublicGetPutDTO publicoUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
