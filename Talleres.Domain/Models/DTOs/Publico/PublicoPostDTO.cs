using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talleres.Domain.Models.DTOs.Publico
{
    public class PublicoPostDTO
    {
        public int EdadMinima { get; set; }
        public int EdadMaxima { get; set; }
        public string Descripcion { get; set; }
    }
}
