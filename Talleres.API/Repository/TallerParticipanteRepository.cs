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
                                                                .Where(t => t.IdTallerProgramacion == id).Include(t => t.TallerProgramacion).ToListAsync();

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

            //Creando respuesta
            tallerParticipantesUsuariosResponseDTO response = new tallerParticipantesUsuariosResponseDTO
            {
                IdTallerProgramacion = taller.Id,
                IdUsuarioInstructor = taller.IdUsuarioInstructor,
                NombreTaller = taller.taller.NombreTaller,
                NumeroParticipantes = taller.NumeroParticipantes,
                Usuarios = usuarios
            };

            return response;
        }

        public async Task<List<tallerParticipantesUsuariosDTO>> GetTallerParticipantesNoIns(int id)
        {
            List<TallerParticipante> tallerParticipanteList = await _db.TallerParticipantes.Where(t => t.IdTallerProgramacion == id).ToListAsync();
            return _mapper.Map<List<tallerParticipantesUsuariosDTO>>(tallerParticipanteList);
        }
    }
}
