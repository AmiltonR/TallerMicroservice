using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talleres.Domain.Models.DTOs
{
    public class tallerParticipantesUsuariosResponseDTO
    {
        public int IdTallerProgramacion { get; set; }
        public int IdUsuarioInstructor { get; set; }
        public string NombreTaller { get; set; }
        public int NumeroParticipantes { get; set; }
        public int Cupos { get; set; }
        public List<tallerParticipantesUsuariosDTO> Usuarios { get; set; }
    }
}
