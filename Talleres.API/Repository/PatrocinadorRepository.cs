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

        public Task<PatrocinadorGetPutDTO> GetPatrocinadorById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> PostPatrocinador(PatrocinadorPostDTO patrocinadorInsert)
        {
            throw new NotImplementedException();
        }

        public Task<bool> PutPatrocinador(PatrocinadorGetPutDTO patrocinadorUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
