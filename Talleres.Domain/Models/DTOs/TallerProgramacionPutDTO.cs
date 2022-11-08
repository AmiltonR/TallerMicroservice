using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talleres.Domain.Models.DTOs
{
    public class TallerProgramacionPutDTO
    {
        public int Id { get; set; }
        public int IdTaller { get; set; }
        public int IdUsuarioInstructor { get; set; }
        public DateTime FechaInicio { get; set; }
        public int NumeroParticipantes { get; set; }
        public int IdPublico { get; set; }
        public double Costo { get; set; }
        public int IdPatrocinador { get; set; }
        public int NumeroSesiones { get; set; }
        public List<HorarioIdGet> Horarios { get; set; }
    }
}
