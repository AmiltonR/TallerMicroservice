using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talleres.Domain.Models.DTOs
{
    public class TallerProgramacionGetEstudianteDTO
    {
        public int Id { get; set; }
        public int IdTaller { get; set; }
        public string NombreTaller { get; set; }
        public int IdUsuarioInstructor { get; set; }
        public string NombreUsuario { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public int NumeroParticipantes { get; set; }
        public string Publico { get; set; }
        public int NumeroSesiones { get; set; }
    }
}
