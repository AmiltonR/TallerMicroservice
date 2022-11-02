using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Talleres.Domain.Entities;
using Talleres.Domain.Models.DTOs;
using Talleres.Infrastructure;

namespace Talleres.API.Repository
{
    public class TallerProgramacionRepository : ITallerProgramacionRepository
    {
        private readonly TallerContext _db;
        private IMapper _mapper;

        public TallerProgramacionRepository(TallerContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<bool> DeleteTaller(int id)
        {
            bool flag = true;
            try
            {
                TallerProgramacion? taller = await _db.TallerProgramaciones.FirstOrDefaultAsync(t => t.Id == id);
                if(taller.Estado == 1)
                {
                    flag = false;
                }
                else
                {
                    _db.TallerProgramaciones.Remove(taller);
                    await _db.SaveChangesAsync();
                }
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
            try
            {
                //Revisar Order By en respuesta con PostMan
                List<TallerProgramacion> talleresList = await _db.TallerProgramaciones.Include(t => t.publico).
                                                                    Include(t => t.patrocinador).
                                                                    Include(t => t.taller).OrderByDescending(t => t.IdTaller)
                                                                    .Where(t => t.Estado == 1).ToListAsync();//order by descending 
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
                        FechaInicio = item.FechaInicio,
                        FechaFinal = item.FechaFinal,
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
            TallerProgramacionGetDTO? tallerDto = null;
            try
            {
                TallerProgramacion? taller = await _db.TallerProgramaciones.FirstOrDefaultAsync(h => h.Id == id);
                tallerDto = _mapper.Map<TallerProgramacionGetDTO>(taller);
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
                                                                    Include(t => t.taller).OrderByDescending(t => t.IdTaller).ToListAsync();//order by descending 
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
                        FechaInicio = item.FechaInicio,
                        FechaFinal = item.FechaFinal,
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
                    tallerProgramacion = await _db.TallerProgramaciones.Where(t => t.Id == item.IdTallerProgramacion)
                                                                        .Include(t => t.publico)
                                                                        .Include(t => t.taller).FirstOrDefaultAsync();

                    //verificar si el taller está activo detenemos la iteración, sino, seguimos buscando el taller activo
                    if (tallerProgramacion.Estado == 1)
                    {
                        break;
                    }
                }

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

        public async Task<bool> PostTaller(TallerProgramacionPostDTO tallerInsert)
        {
            bool flag = false;

            try
            {
                TallerProgramacion tallerPost = _mapper.Map<TallerProgramacionPostDTO, TallerProgramacion>(tallerInsert);
                _db.TallerProgramaciones.Add(tallerPost);
                await _db.SaveChangesAsync();
                flag = true;
                //Enviar notificación de asignación de taller. Enviar nombre Taller y Horarios
                //Crear DTOs Notificaiones?
            }
            catch (Exception)
            {
                throw;
            }
            return flag;
        }

        public async Task<bool> PutTaller(TallerProgramacionPutDTO tallerUpdate)
        {
            bool flag = false;
            try
            {
                TallerProgramacion tallerPut = _mapper.Map<TallerProgramacionPutDTO, TallerProgramacion>(tallerUpdate);
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

        
    }
}
