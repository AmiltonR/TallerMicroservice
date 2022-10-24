using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talleres.Domain.Models.DTOs.Patrocinador
{
    public class PatrocinadorGetPutDTO
    {
        public int Id { get; set; }
        public string NombrePatrocinador { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

    }
}
