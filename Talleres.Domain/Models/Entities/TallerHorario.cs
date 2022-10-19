using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Talleres.Domain.Entities
{
    public class TallerHorario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [ForeignKey("TallerProgramacion")]
        public int IdTallerProgramacion { get; set; }
        [Required]
        [ForeignKey("Horario")]
        public int IdHorario { get; set; }

        [ForeignKey("IdTallerProgramacion")]
        public virtual TallerProgramacion TallerProgramacion { get; set; }
        [ForeignKey("IdHorario")]
        public virtual Horario Horario { get; set; }
    }
}
