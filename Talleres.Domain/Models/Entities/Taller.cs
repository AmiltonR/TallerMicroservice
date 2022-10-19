using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talleres.Domain.Entities
{
    public class Taller
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string NombreTaller { get; set; }
        [Required]
        public string Descripcion { get; set; }

        //Colecciones
        public virtual ICollection<TallerProgramacion> TallerProgramacion { get; set; }
    }
}
