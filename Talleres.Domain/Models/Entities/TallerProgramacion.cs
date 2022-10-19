using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talleres.Domain.Entities
{
    public class TallerProgramacion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [ForeignKey("taller")]
        public int IdTaller { get; set; }
        [Required]
        public int IdUsuarioInstructor { get; set; }
        [Required]
        public DateTime FechaInicio { get; set; }
        [Required]
        public DateTime FechaFinal { get; set; }
        [Required]
        public int NumeroParticipantes { get; set; }
        [Required]
        [ForeignKey("publico")]
        public int IdPublico { get; set; }
        [Required]
        public double Costo { get; set; } = 0.00;
        [Required]
        [ForeignKey("patrocinador")]
        public int IdPatrocinador { get; set; }
        [Required]
        public int NumeroSesiones { get; set; }
        [Required]
        public int Estado { get; set; } = 1;

        //Laves foráneas
        [ForeignKey("IdTaller")]
        public virtual Taller taller { get; set; }
        [ForeignKey("IdPublico")]
        public virtual Publico publico { get; set; }
        [ForeignKey("IdPatrocinador")]
        public virtual Patrocinador patrocinador { get; set; }

        //Colecciones
        public virtual ICollection<TallerAsistencia> TallerAsistencias { get; set; }
        public virtual ICollection<TallerParticipante> TallerParticipantes { get; set; }
        public virtual ICollection<TallerHorario> TallerHorarios { get; set; }
    }
}
