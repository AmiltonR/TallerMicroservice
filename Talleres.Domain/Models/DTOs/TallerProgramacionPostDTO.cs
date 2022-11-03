using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talleres.Domain.Entities;

namespace Talleres.Domain.Models.DTOs
{
    public class TallerProgramacionPostDTO
    {
        public int IdTaller { get; set; }
        public int IdUsuarioInstructor { get; set; }
        public DateTime FechaInicio { get; set; }
        public int NumeroParticipantes { get; set; }
        public int IdPublico { get; set; }
        public double Costo { get; set; }
        public int IdPatrocinador { get; set; }
        public int NumeroSesiones { get; set; }
        //Lista de horarios. El taller se puede impartir en uno o más horarios
        //Este atributo alimenta la entidad TallerHorario

        //      |ID|IdTallerProgramacion|IdHorario|

        public List<HorarioIdGet> Horarios { get; set; }
    }
}
