using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talleres.Domain.Entities
{
    public class Publico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int EdadMinima { get; set; }
        [Required]
        public int EdadMaxima { get; set; }
        [Required]
        public string Descripcion { get; set; }

        public virtual ICollection<TallerProgramacion> TallerProgramaciones { get; set; }
    }
}
