using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talleres.Domain.Models.DTOs
{
    public class TallerGetDTO
    {
        public int Id { get; set; }
        public string NombreTaller { get; set; }
        public string Descripcion { get; set; }
    }
}
