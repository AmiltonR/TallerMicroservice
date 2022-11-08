using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talleres.Domain.Models.DTOs
{
    public class TallerProgramacionGetDTO
    {
        public int Id { get; set; }
        public int IdTaller { get; set; }
        public string NombreTaller { get; set; }
        public int IdUsuarioInstructor { get; set; }
        public string NombreUsuario { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFinal { get; set; }
        public int NumeroParticipantes { get; set; }
        public string Publico { get; set; }
        public double Costo { get; set; }
        public string NombrePatrocinador { get; set; }
        public int NumeroSesiones { get; set; }
        
    }
}
