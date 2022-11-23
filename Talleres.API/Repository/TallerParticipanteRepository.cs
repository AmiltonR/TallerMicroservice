using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Talleres.Domain.DTOs;
using Talleres.Domain.Entities;
using Talleres.Domain.Models.DTOs;
using Talleres.Infrastructure;

namespace Talleres.API.Repository
{
    public class TallerParticipanteRepository : ITallerParticipanteRepository
    {
        private IMapper _mapper;
        private readonly TallerContext _db;

        public TallerParticipanteRepository(IMapper mapper, TallerContext db)
        {
            _mapper = mapper;
            _db = db;
        }

        //Devuelve los participantes de un taller dado
        //verificar implicación en agregado
        public async Task<tallerParticipantesUsuariosResponseDTO> GetTallerParticipantes(int id)
        {
            //Taller
            TallerProgramacion taller = await _db.TallerProgramaciones.Where(t=>t.Id==id).Include(t=>t.taller).FirstOrDefaultAsync();
            //Retornar lista de partipantes
            List<TallerParticipante> tallerParticipanteList = await _db.TallerParticipantes
                                                                .Where(t => t.IdTallerProgramacion == id).Include(t => t.TallerProgramacion).
                                                                OrderBy(t => t.IdUsuario)
                                                                .ToListAsync();

            List<tallerParticipantesUsuariosDTO> usuarios = new List<tallerParticipantesUsuariosDTO>();
            tallerParticipantesUsuariosDTO user = null;

            foreach (var item in tallerParticipanteList)
            {
                user = new tallerParticipantesUsuariosDTO
                {
                    IdUsuario = item.IdUsuario
                };
                usuarios.Add(user);
            }

            int restantes = taller.NumeroParticipantes-tallerParticipanteList.Count;
            //Creando respuesta
            tallerParticipantesUsuariosResponseDTO response = new tallerParticipantesUsuariosResponseDTO
            {
                IdTallerProgramacion = taller.Id,
                IdUsuarioInstructor = taller.IdUsuarioInstructor,
                NombreTaller = taller.taller.NombreTaller,
                NumeroParticipantes = taller.NumeroParticipantes,
                Cupos = restantes,
                Usuarios = usuarios
            };

            return response;
        }

        public async Task<List<tallerParticipantesUsuariosDTO>> GetTallerParticipantesNoIns(int id)
        {
            List<TallerParticipante> tallerParticipanteList = await _db.TallerParticipantes.Where(t => t.IdTallerProgramacion == id).ToListAsync();

            List<tallerParticipantesUsuariosDTO> usuarios = new List<tallerParticipantesUsuariosDTO>();
            tallerParticipantesUsuariosDTO usuario = null;
            foreach (var item in tallerParticipanteList)
            {
                usuario = new tallerParticipantesUsuariosDTO
                {
                    IdUsuario = item.IdUsuario
                };
                usuarios.Add(usuario);
            }
            return usuarios;
        }

        public async Task<bool> PostParticipantes(TallerParticipantePostDTO tallerParticipantePost)
        {   //TODO: agregar transactions
            bool flag = false;
            try
            {
                //recorremos la respuesta y guardamos los usuarios
                foreach (var item in tallerParticipantePost.usuarios)
                {
                    TallerParticipante participante = new TallerParticipante
                    {
                        IdTallerProgramacion = tallerParticipantePost.IdTallerProgramacion,
                        IdUsuario = item.IdUsuario
                    };
                    _db.TallerParticipantes.Add(participante);
                    await _db.SaveChangesAsync();
                }
                flag = true;
            }
            catch (Exception)
            {
                throw;
            }
            return flag;
        }

        public async Task<bool> PostParticipantesAceptaSolicitud(int id)
        {
            bool flag = false;
            Solicitud sol = null;
            try
            {
                sol = await _db.Solicitudes.Where(s => s.Id == id).FirstOrDefaultAsync();
                TallerParticipante participante = new TallerParticipante
                {
                    IdUsuario = sol.IdUsuario,
                    IdTallerProgramacion = sol.IdTallerProgramacion
                };
                _db.TallerParticipantes.Add(participante);
                _db.Solicitudes.Remove(sol);
                await _db.SaveChangesAsync();
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
