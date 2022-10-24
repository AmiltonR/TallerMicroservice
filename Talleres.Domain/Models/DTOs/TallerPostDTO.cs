using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talleres.Domain.Models.DTOs
{
    public class TallerPostDTO
    {
        public string NombreTaller { get; set; }
        public string Descripcion { get; set; }
    }
}
