using Talleres.Domain.DTOs;

namespace Talleres.API.Repository
{
    public interface ITallerParticipanteRepository
    {
        Task<IEnumerable<TallerParticipanteGetDTO>> GetTallerParticipantes(int id);

    }
}
