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

        public Task<bool> DeleteTaller(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TallerGetDTO>> GetTalleres()
        {
            List<Taller> talleresList = await _db.Talleres.ToListAsync();
            return _mapper.Map<List<TallerGetDTO>>(talleresList);
            
        }

        //Get All Talleres
        public async Task<TallerGetDTO> GetTaller(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> PostTaller(TallerPostDTO tallerInsert)
        {
            throw new NotImplementedException();
        }

        public Task<bool> PutTaller(TallerGetDTO horarioTaller)
        {
            throw new NotImplementedException();
        }

        public Task<bool> verifyExistence(string nombre)
        {
            throw new NotImplementedException();
        }
    }
}
