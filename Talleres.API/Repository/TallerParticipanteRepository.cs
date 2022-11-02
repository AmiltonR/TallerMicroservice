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

        //Devuelve los participantes de un taller dado
        //verificar implicación en agregado
        public async Task<IEnumerable<TallerParticipanteGetDTO>> GetTallerParticipantes(int id)
        {
            List<TallerParticipante> tallerParticipanteList = await _db.TallerParticipantes
                                                                .Where(t => t.IdTallerProgramacion == id).ToListAsync();

            return _mapper.Map<List<TallerParticipanteGetDTO>>(tallerParticipanteList);
        }
    }
}
