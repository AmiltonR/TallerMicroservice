using AutoMapper;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Talleres.API.Utilities;
using Talleres.Domain.Entities;
using Talleres.Domain.Models.DTOs;
using Talleres.Infrastructure;

namespace Talleres.API.Repository
{
    public class TallerProgramacionRepository : ITallerProgramacionRepository
    {
        private readonly TallerContext _db;
        private readonly CalcularFechaFinal _calcularFechaFinal;
        private IMapper _mapper;

        public TallerProgramacionRepository(TallerContext db, IMapper mapper, CalcularFechaFinal calcularFechaFinal)
        {
            _db = db;
            _mapper = mapper;
            _calcularFechaFinal = calcularFechaFinal;
        }
        public async Task<bool> DeleteTaller(int id)
        {
            //Comprobar que no tenga participantes
            bool flag = true;
            try
            {
                TallerProgramacion taller = await _db.TallerProgramaciones.FirstOrDefaultAsync(t => t.Id == id);
                bool hasParticipantes = _db.TallerParticipantes.Any(p => p.IdTallerProgramacion == id);
               //pending
            }
            catch (Exception)
            {
                throw;
            }
            return flag;
        }

        //Get all active talleres
        public async Task<IEnumerable<TallerProgramacionGetDTO>> GetActiveTalleres()
        {
            List<TallerProgramacionGetDTO> talleres = new List<TallerProgramacionGetDTO>();
            //revisar talleres actvos
            try
            {
                //Revisar Order By en respuesta con PostMan
                List<TallerProgramacion> talleresList = await _db.TallerProgramaciones.Include(t => t.publico).
                                                                    Include(t => t.patrocinador).
                                                                    Include(t => t.taller)
                                                                    .Where(t => t.Estado == 1).OrderByDescending(t => t.Id).ToListAsync();//order by descending 
                //Recorremos el arreglo
                TallerProgramacionGetDTO tallerForEach = null;
                foreach (var item in talleresList)
                {
                    tallerForEach = new TallerProgramacionGetDTO
                    {
                        Id = item.Id,
                        IdTaller = item.IdTaller,
                        NombreTaller = item.taller.NombreTaller,
                        IdUsuarioInstructor = item.IdUsuarioInstructor,
                        NombreUsuario = "Pending...",
                        FechaInicio = item.FechaInicio.ToShortDateString(),
                        FechaFinal = item.FechaFinal.ToShortDateString(),
                        NumeroParticipantes = item.NumeroParticipantes,
                        Publico = item.publico.Descripcion,
                        Costo = item.Costo,
                        NombrePatrocinador = item.patrocinador.NombrePatrocinador,
                        NumeroSesiones = item.NumeroSesiones
                    };
                    talleres.Add(tallerForEach);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return talleres;
        }

        public async Task<TallerProgramacionGetDTO> GetTallerById(int id)
        {
            TallerProgramacionGetDTO tallerDto = null;
            try
            {
                TallerProgramacion? taller = await _db.TallerProgramaciones.Include(t => t.patrocinador)
                                                        .Include(t=>t.taller).Include(t => t.publico).FirstOrDefaultAsync(h => h.Id == id);
                tallerDto = new TallerProgramacionGetDTO
                {
                    Id = taller.Id,
                    IdTaller = taller.IdTaller,
                    NombreTaller = taller.taller.NombreTaller,
                    IdUsuarioInstructor = taller.IdUsuarioInstructor,
                    NombreUsuario = String.Empty,
                    FechaInicio = taller.FechaInicio.ToShortDateString(),
                    FechaFinal = taller.FechaFinal.ToShortDateString(),
                    NumeroParticipantes = taller.NumeroParticipantes,
                    Publico = taller.publico.Descripcion,
                    Costo = taller.Costo,
                    NombrePatrocinador = taller.patrocinador.NombrePatrocinador,
                    NumeroSesiones = taller.NumeroSesiones
                };
            }
            catch (Exception)
            {
                throw;
            }
            return tallerDto;
        }

        //Get all talleres
        public async Task<IEnumerable<TallerProgramacionGetDTO>> GetTalleres()
        {
            List<TallerProgramacionGetDTO> talleres = new List<TallerProgramacionGetDTO>();
            try
            {
                //Revisar Order By en respuesta con PostMan
                List<TallerProgramacion> talleresList = await _db.TallerProgramaciones.Include(t => t.publico).
                                                                    Include(t => t.patrocinador).
                                                                    Include(t => t.taller).OrderByDescending(t => t.IdTaller).OrderByDescending(t => t.Id).ToListAsync();//order by descending 
                //Recorremos el arreglo
                TallerProgramacionGetDTO tallerForEach = null;
                foreach (var item in talleresList)
                {
                    tallerForEach = new TallerProgramacionGetDTO
                    {
                        Id = item.Id,
                        IdTaller = item.IdTaller,
                        NombreTaller = item.taller.NombreTaller,
                        IdUsuarioInstructor = item.IdUsuarioInstructor,
                        NombreUsuario = "Pending...",
                        FechaInicio = item.FechaInicio.ToShortDateString(),
                        FechaFinal = item.FechaFinal.ToShortDateString(),
                        NumeroParticipantes = item.NumeroParticipantes,
                        Publico = item.publico.Descripcion,
                        Costo = item.Costo,
                        NombrePatrocinador = item.patrocinador.NombrePatrocinador,
                        NumeroSesiones = item.NumeroSesiones
                    };
                    talleres.Add(tallerForEach);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return talleres;
        }

        //Traer el taller activo donde está el estudiante
        public async Task<TallerProgramacionGetEstudianteDTO> GetTallerByUser(int idUsuario)
        {
            TallerProgramacionGetEstudianteDTO taller = null;
            try
            {
                //Traemos todos los id de los talleres en donde esté el usuario x
                IEnumerable<TallerParticipante> tallerParticipanteList = await _db.TallerParticipantes.Where(t => t.IdUsuario == idUsuario).ToListAsync();

                //Traemos de tallerProgramacion la data haciendo uso de los id extraidos

                TallerProgramacion? tallerProgramacion = null;

                foreach (var item in tallerParticipanteList)
                {
                    tallerProgramacion = await _db.TallerProgramaciones.Where(t => t.Id == item.IdTallerProgramacion && t.Estado == 1)
                                                                        .Include(t => t.publico)
                                                                        .Include(t => t.taller).FirstOrDefaultAsync();
                    
                }

                //¿No hay Taller?
                if (tallerProgramacion!=null)
                {
                    taller = new TallerProgramacionGetEstudianteDTO
                    {
                        Id = tallerProgramacion.Id,
                        IdTaller = tallerProgramacion.IdTaller,
                        NombreTaller = tallerProgramacion.taller.NombreTaller,
                        IdUsuarioInstructor = tallerProgramacion.IdUsuarioInstructor,
                        NombreUsuario = "Pending...",
                        FechaInicio = tallerProgramacion.FechaInicio,
                        FechaFinal = tallerProgramacion.FechaFinal,
                        NumeroParticipantes = tallerProgramacion.NumeroParticipantes,
                        Publico = tallerProgramacion.publico.Descripcion,
                        NumeroSesiones = tallerProgramacion.NumeroSesiones
                    };
                }
            }
            catch (Exception)
            {
                throw;
            }
            return taller;
        }

        public async Task<IEnumerable<TallerProgramacionGetEstudianteDTO>> GetTalleresByUser(int idUsuario)
        {
            List<TallerProgramacionGetEstudianteDTO> tallerList = new List<TallerProgramacionGetEstudianteDTO>();
            try
            {
                //Traemos todos los id de los talleres en donde esté el usuario x
                IEnumerable<TallerParticipante> tallerParticipanteList = await _db.TallerParticipantes.Where(t => t.IdUsuario == idUsuario).ToListAsync();

                //Traemos de tallerProgramacion la data haciendo uso de los id extraidos
                TallerProgramacion? tallerProgramacion = null;
                TallerProgramacionGetEstudianteDTO tallerForeach = null;
                foreach (var item in tallerParticipanteList)
                {
                    tallerProgramacion = await _db.TallerProgramaciones.Where(t => t.Id == item.IdTallerProgramacion).FirstOrDefaultAsync();

                    tallerForeach = new TallerProgramacionGetEstudianteDTO
                    {
                        Id = tallerProgramacion.Id,
                        IdTaller = tallerProgramacion.IdTaller,
                        NombreTaller = tallerProgramacion.taller.NombreTaller,
                        IdUsuarioInstructor = tallerProgramacion.IdUsuarioInstructor,
                        NombreUsuario = "Pending...",
                        FechaInicio = tallerProgramacion.FechaInicio,
                        FechaFinal = tallerProgramacion.FechaFinal,
                        NumeroParticipantes = tallerProgramacion.NumeroParticipantes,
                        Publico = tallerProgramacion.publico.Descripcion,
                        NumeroSesiones = tallerProgramacion.NumeroSesiones
                    };
                    tallerList.Add(tallerForeach);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return tallerList;
        }

        public async Task<int> PostTaller(TallerProgramacionPostDTO tallerInsert)
        {
            int flag = 0;
            using var transaction = _db.Database.BeginTransaction();
            try
            {
                //*** Steps ***
                //1. Verificar que no haya un taller Activo con el mismo idTaller?
            //2. Iterar arreglo de Horarios y crear objetos para almacenar: IdHorario, Dias
                List<Horario> horarios = new List<Horario>();
                Horario horario = null;

                //Recorremos el arreglo y creamos lista de Horarios
                foreach (var item in tallerInsert.Horarios)
                {
                    horario = await _db.Horario.Where(h => h.Id == item.Id).FirstOrDefaultAsync();
                    horarios.Add(horario);
                }

            //3. Calcular fecha Final con base en numero de sesiones
                //Array para almacenar dias 
                string[] diasTaller = new string[horarios.Count];

                //Recorremos la lista de horarios y llenamos la lista de dias
                int i = 0;
                foreach (var item in horarios)
                {
                    diasTaller[i] = item.Dia;
                    i++;
                }

                DateTime fechaFinal = _calcularFechaFinal.Calcular(diasTaller, tallerInsert.NumeroSesiones, tallerInsert.FechaInicio);

                //4. Crear objeto TallerProgramacion y guardarlo
                TallerProgramacion taller = new TallerProgramacion
                {
                    IdTaller = tallerInsert.IdTaller,
                    IdUsuarioInstructor = tallerInsert.IdUsuarioInstructor,
                    FechaInicio = tallerInsert.FechaInicio,
                    FechaFinal = fechaFinal,
                    NumeroParticipantes = tallerInsert.NumeroParticipantes,
                    IdPublico = tallerInsert.IdPublico,
                    Costo = tallerInsert.Costo,
                    IdPatrocinador = tallerInsert.IdPatrocinador,
                    NumeroSesiones = tallerInsert.NumeroSesiones
                };

                _db.TallerProgramaciones.Add(taller);
                await _db.SaveChangesAsync();
                //Prueba de envío de correo
                

                //5. Traer el id del taller programacion recien guardado y Guardar lista de horarios
                int idTallerProgramacion = _db.TallerProgramaciones.Max(t => t.Id);

                foreach (var item in horarios)
                {
                    TallerHorario horarioTaller = new TallerHorario
                    {
                        IdHorario = item.Id,
                        IdTallerProgramacion = idTallerProgramacion
                    };
                    _db.TallerHorarios.Add(horarioTaller);
                    await _db.SaveChangesAsync();
                }

                //Pasos siguientes:
                //  1. Agregar participantes (Mientras no se logre el numero de participantes límite) --DONE
                //  2. Enviar notificación de asignación de taller. Enviar nombre Taller y Horarios



                    //Recuperar el usuario?
                //EmailSender.Principal("¡Se le ha asignado a un Taller! Ingrese a la app para más detalles");
                //  3. Crear DTOs Notificaciones?


                transaction.Commit();
                flag = 1;
                
            }
            catch (Exception)
            {
                throw;
            }
            return flag;
        }

        public async Task<bool> PutTaller(TallerProgramacionPutDTO tallerUpdate)
        {
            //TODO: ENviar Notificacion de actualizacion de taller
            //Pedir autorización en el frontend si la fecha de inicio que se pretende cambiar 
            //Es diferente
            bool flag = false;
            try
            {
                TallerProgramacion tallerPut = _mapper.Map<TallerProgramacionPutDTO, TallerProgramacion>(tallerUpdate);
                List<Horario> horarios = new List<Horario>();
                Horario horario = null;

                foreach (var item in tallerUpdate.Horarios)
                {
                    horario = await _db.Horario.Where(h => h.Id == item.Id).FirstOrDefaultAsync();
                    horarios.Add(horario);
                }

                string[] diasTaller = new string[horarios.Count];

                int i = 0;
                foreach (var item in horarios)
                {
                    diasTaller[i] = item.Dia;
                    i++;
                }

                tallerPut.FechaFinal = _calcularFechaFinal.Calcular(diasTaller, tallerPut.NumeroSesiones, tallerPut.FechaInicio);

                _db.TallerProgramaciones.Update(tallerPut);
                await _db.SaveChangesAsync();
                flag = true;

                //Enviar notificación de actualización de Taller

            }
            catch (Exception)
            {
                throw;
            }
            return flag;
        }

        public async Task<bool> SetInactive(int Id, int op)
        {
            //Utilicese cuando 
            int _Id = Id;
            int option = op;
            bool flag = false;
            try
            {
                TallerProgramacionDeleteDTO tallerSetInactive = null;
                if (op == 0)
                {
                    tallerSetInactive = new TallerProgramacionDeleteDTO
                    {
                        Id = _Id,
                        Estado = 0
                    };
                }
                else
                {
                    tallerSetInactive = new TallerProgramacionDeleteDTO
                    {
                        Id = _Id,
                        Estado = 1
                    };
                }

                TallerProgramacion tallerP = _mapper.Map<TallerProgramacionDeleteDTO, TallerProgramacion>(tallerSetInactive);
                _db.TallerProgramaciones.Attach(tallerP);
                _db.Entry(tallerP).Property(x => x.Estado).IsModified = true;
                _db.SaveChanges();

                flag = true;
            }
            catch (Exception)
            {
                throw;
            }
            return flag;
        }

        public async Task<List<TallerProgramacionGetDTO>> GetTalleresByInstructor(int id)
        {
            IEnumerable<TallerProgramacion> tallerProgramacionList = await _db.TallerProgramaciones.Where(t => t.IdUsuarioInstructor == id)
                                                                            .Include(t => t.taller).Include(t => t.publico)
                                                                            .Include(t => t.patrocinador).ToListAsync();
            List<TallerProgramacionGetDTO> lista = new List<TallerProgramacionGetDTO>();
            TallerProgramacionGetDTO taller = null;

            foreach (var item in tallerProgramacionList)
            {
                taller = new TallerProgramacionGetDTO
                {
                    Id = item.Id,
                    IdTaller= item.IdTaller,
                    NombreTaller = item.taller.NombreTaller,
                    IdUsuarioInstructor = item.IdUsuarioInstructor,
                    NombreUsuario = "Pending...",
                    FechaInicio = item.FechaInicio.ToShortDateString(),
                    FechaFinal = item.FechaFinal.ToShortDateString(),
                    NumeroParticipantes = item.NumeroParticipantes,
                    Publico = item.publico.Descripcion,
                    Costo = item.Costo,
                    NombrePatrocinador = item.patrocinador.NombrePatrocinador,
                    NumeroSesiones = item.NumeroSesiones,
                };
                lista.Add(taller);
            }
            return lista;
        }
    }
}
