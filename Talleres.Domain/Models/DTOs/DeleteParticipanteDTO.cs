using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talleres.Domain.Models.DTOs
{
    public class DeleteParticipanteDTO
    {
        public int IdUsuario { get; set; }
        public int IdTallerProgramacion { get; set; }
    }
}
