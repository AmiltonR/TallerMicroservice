using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talleres.Domain.Entities
{
    public class TallerParticipante
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [ForeignKey("TallerProgramacion")]
        public int IdTallerProgramacion { get; set; }
        [Required]
        public int IdUsuario { get; set; }

        [ForeignKey("IdTallerProgramacion")]
        public virtual TallerProgramacion TallerProgramacion { get; set; }
    }
}
