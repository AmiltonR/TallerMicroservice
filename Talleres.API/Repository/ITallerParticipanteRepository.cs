using Talleres.Domain.DTOs;
using Talleres.Domain.Models.DTOs;

namespace Talleres.API.Repository
{
    public interface ITallerParticipanteRepository
    {
        Task<IEnumerable<tallerParticipantesUsuariosDTO>> GetTallerParticipantes(int id);

    }
}
