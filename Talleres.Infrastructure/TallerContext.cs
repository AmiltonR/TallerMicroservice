using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talleres.Domain.Entities;

namespace Talleres.Infrastructure
{
    public class TallerContext:DbContext
    {
        public TallerContext(DbContextOptions<TallerContext> options) : base(options)
        {

        }

        public DbSet<Taller> Talleres{ get; set; }
        public DbSet<TallerParticipante> TallerParticipantes { get; set; }
        public DbSet<Horario> Horario { get; set; }
        //public DbSet<Notificacion> Notificaciones { get; set; }
        public DbSet<Publico> Publicos { get; set; }
        //public DbSet<Solicitud> Solicitudes { get; set; }
        public DbSet<TallerAsistencia> TallerAsistencias { get; set; }
        public DbSet<TallerHorario> TallerHorarios { get; set; }
        public DbSet<TallerProgramacion> TallerProgramaciones { get; set; }


    }
}
