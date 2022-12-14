// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Talleres.Infrastructure;

#nullable disable

namespace Talleres.Infrastructure.Migrations
{
    [DbContext(typeof(TallerContext))]
    partial class TallerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Talleres.Domain.Entities.Horario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Dia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("HoraFinal")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("HoraInicio")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.ToTable("Horario");
                });

            modelBuilder.Entity("Talleres.Domain.Entities.Notificacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<string>("Notification")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Notificaciones");
                });

            modelBuilder.Entity("Talleres.Domain.Entities.Patrocinador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombrePatrocinador")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Patrocinadores");
                });

            modelBuilder.Entity("Talleres.Domain.Entities.Publico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EdadMaxima")
                        .HasColumnType("int");

                    b.Property<int>("EdadMinima")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Publicos");
                });

            modelBuilder.Entity("Talleres.Domain.Entities.Solicitud", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("IdTallerProgramacion")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdTallerProgramacion");

                    b.ToTable("Solicitudes");
                });

            modelBuilder.Entity("Talleres.Domain.Entities.Taller", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreTaller")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Talleres");
                });

            modelBuilder.Entity("Talleres.Domain.Entities.TallerAsistencia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Asistencia")
                        .HasColumnType("int");

                    b.Property<int>("IdTallerProgramacion")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<int>("NumeroSesion")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdTallerProgramacion");

                    b.ToTable("TallerAsistencias");
                });

            modelBuilder.Entity("Talleres.Domain.Entities.TallerHorario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("IdHorario")
                        .HasColumnType("int");

                    b.Property<int>("IdTallerProgramacion")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdHorario");

                    b.HasIndex("IdTallerProgramacion");

                    b.ToTable("TallerHorarios");
                });

            modelBuilder.Entity("Talleres.Domain.Entities.TallerParticipante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("IdTallerProgramacion")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdTallerProgramacion");

                    b.ToTable("TallerParticipantes");
                });

            modelBuilder.Entity("Talleres.Domain.Entities.TallerProgramacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("Costo")
                        .HasColumnType("float");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaFinal")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdPatrocinador")
                        .HasColumnType("int");

                    b.Property<int>("IdPublico")
                        .HasColumnType("int");

                    b.Property<int>("IdTaller")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuarioInstructor")
                        .HasColumnType("int");

                    b.Property<int>("NumeroParticipantes")
                        .HasColumnType("int");

                    b.Property<int>("NumeroSesiones")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdPatrocinador");

                    b.HasIndex("IdPublico");

                    b.HasIndex("IdTaller");

                    b.ToTable("TallerProgramaciones");
                });

            modelBuilder.Entity("Talleres.Domain.Entities.Solicitud", b =>
                {
                    b.HasOne("Talleres.Domain.Entities.TallerProgramacion", "TallerProgramacion")
                        .WithMany()
                        .HasForeignKey("IdTallerProgramacion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TallerProgramacion");
                });

            modelBuilder.Entity("Talleres.Domain.Entities.TallerAsistencia", b =>
                {
                    b.HasOne("Talleres.Domain.Entities.TallerProgramacion", "TallerProgramacion")
                        .WithMany("TallerAsistencias")
                        .HasForeignKey("IdTallerProgramacion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TallerProgramacion");
                });

            modelBuilder.Entity("Talleres.Domain.Entities.TallerHorario", b =>
                {
                    b.HasOne("Talleres.Domain.Entities.Horario", "Horario")
                        .WithMany("TallerHorarios")
                        .HasForeignKey("IdHorario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Talleres.Domain.Entities.TallerProgramacion", "TallerProgramacion")
                        .WithMany("TallerHorarios")
                        .HasForeignKey("IdTallerProgramacion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Horario");

                    b.Navigation("TallerProgramacion");
                });

            modelBuilder.Entity("Talleres.Domain.Entities.TallerParticipante", b =>
                {
                    b.HasOne("Talleres.Domain.Entities.TallerProgramacion", "TallerProgramacion")
                        .WithMany("TallerParticipantes")
                        .HasForeignKey("IdTallerProgramacion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TallerProgramacion");
                });

            modelBuilder.Entity("Talleres.Domain.Entities.TallerProgramacion", b =>
                {
                    b.HasOne("Talleres.Domain.Entities.Patrocinador", "patrocinador")
                        .WithMany("TallerProgramaciones")
                        .HasForeignKey("IdPatrocinador")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Talleres.Domain.Entities.Publico", "publico")
                        .WithMany("TallerProgramaciones")
                        .HasForeignKey("IdPublico")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Talleres.Domain.Entities.Taller", "taller")
                        .WithMany("TallerProgramacion")
                        .HasForeignKey("IdTaller")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("patrocinador");

                    b.Navigation("publico");

                    b.Navigation("taller");
                });

            modelBuilder.Entity("Talleres.Domain.Entities.Horario", b =>
                {
                    b.Navigation("TallerHorarios");
                });

            modelBuilder.Entity("Talleres.Domain.Entities.Patrocinador", b =>
                {
                    b.Navigation("TallerProgramaciones");
                });

            modelBuilder.Entity("Talleres.Domain.Entities.Publico", b =>
                {
                    b.Navigation("TallerProgramaciones");
                });

            modelBuilder.Entity("Talleres.Domain.Entities.Taller", b =>
                {
                    b.Navigation("TallerProgramacion");
                });

            modelBuilder.Entity("Talleres.Domain.Entities.TallerProgramacion", b =>
                {
                    b.Navigation("TallerAsistencias");

                    b.Navigation("TallerHorarios");

                    b.Navigation("TallerParticipantes");
                });
#pragma warning restore 612, 618
        }
    }
}
