using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Talleres.Domain.DTOs;
using Talleres.Domain.Entities;
using Talleres.Infrastructure;

namespace Talleres.API.Repository
{
    public class TallerParticipanteRepository : ITallerParticipanteRepository
    {
        private IMapper _mapper;
        private readonly TallerContext _db;

        public TallerParticipanteRepository(IMapper mapper, TallerContext db)
        {
            _mapper = mapper;
            _db = db;
        }

        public async Task<IEnumerable<TallerParticipanteGetDTO>> GetTallerParticipantes()
        {

            List<TallerParticipante> tallerParticipanteList = await _db.TallerParticipantes.ToListAsync();
            return _mapper.Map<List<TallerParticipanteGetDTO>>(tallerParticipanteList);
        }
    }
}
