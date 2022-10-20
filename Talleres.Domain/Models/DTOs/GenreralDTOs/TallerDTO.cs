using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talleres.Domain.Models.DTOs.GenreralDTOs
{
    public class TallerDTO
    {
        public int Id { get; set; }
        public string NombreTaller { get; set; }
        public string Descripcion { get; set; }
    }
}
