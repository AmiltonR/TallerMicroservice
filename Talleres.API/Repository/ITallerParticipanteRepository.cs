using Talleres.Domain.DTOs;
using Talleres.Domain.Models.DTOs;

namespace Talleres.API.Repository
{
    public interface ITallerParticipanteRepository
    {
        Task<tallerParticipantesUsuariosResponseDTO> GetTallerParticipantes(int id);
        Task<List<tallerParticipantesUsuariosDTO>> GetTallerParticipantesNoIns(int id);
        Task<bool> PostParticipantes(TallerParticipantePostDTO tallerParticipantePost);
        Task<bool> PostParticipantesAceptaSolicitud(int id);
    }
}
