using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talleres.Domain.Models.DTOs
{
    public class TallerParticipantePostDTO
    {
        public int IdTallerProgramacion { get; set; }
        public List<tallerParticipantesUsuariosDTO> usuarios { get; set; }
    }
}
