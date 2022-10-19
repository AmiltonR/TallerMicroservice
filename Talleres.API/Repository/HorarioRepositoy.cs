using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Talleres.Domain.Entities;
using Talleres.Domain.Models.DTOs.GetDTOs;
using Talleres.Domain.Models.DTOs.PostDTO;
using Talleres.Infrastructure;

namespace Talleres.API.Repository
{
    public class HorarioRepositoy : IHorarioRepository
    {
        private readonly TallerContext _db;
        private IMapper _mapper;

        public HorarioRepositoy(TallerContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<HorarioGetPostPutDTO> GetHorarioById(int id)
        {
            Horario? horarioDB = await _db.Horario.FirstOrDefaultAsync(h => h.Id == id);
            HorarioGetPostPutDTO? horarioDTO = _mapper.Map<HorarioGetPostPutDTO>(horarioDB);
            return horarioDTO;
        }

        public async Task<IEnumerable<HorarioGetPostPutDTO>> GetHorarios()
        {
            List<Horario> horariosList = await _db.Horario.ToListAsync();
            return _mapper.Map<List<HorarioGetPostPutDTO>>(horariosList);
        }

        public async Task<bool> PostHorario(HorarioPostDTO horarioInsert)
        {
            bool flag = false;
            try
            {
                Horario horarioPost = _mapper.Map<HorarioPostDTO, Horario>(horarioInsert);
                _db.Horario.Add(horarioPost);
                await _db.SaveChangesAsync();
                flag = true;
            }
            catch (Exception)
            {

                throw;
            }
            return flag;
        }

        public async Task<bool> PutHorario(HorarioGetPostPutDTO horarioUpdate)
        {
            bool flag = false;
            try
            {
                Horario horarioPut = _mapper.Map<HorarioGetPostPutDTO, Horario>(horarioUpdate);
                _db.Horario.Update(horarioPut);
                await _db.SaveChangesAsync();
                flag = true;
            }
            catch (Exception)
            {

                throw;
            }
            return flag;
        }
        public async Task<bool> DeleteHorario(int id)
        {
            bool flag = false;
            try
            {
                Horario? horarioDelete = await _db.Horario.FirstOrDefaultAsync(h => h.Id == id);
                //TO-DO
                //Lógica para revisar implicación en otra entidad antes de eliminar
                _db.Horario.Remove(horarioDelete);
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
