using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talleres.Domain.DTOs
{
    public class TallerParticipanteGetDTO
    {
        public int Id { get; set; }
        public int IdTallerProgramacion { get; set; }
        public int IdUsuario { get; set; }
        public string NombreTaller { get; set; }
    }
}
