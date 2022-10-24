using Talleres.Domain.Models.DTOs;

namespace Talleres.API.Repository
{
    public interface IHorarioRepository
    {
        //Get Method
        Task<IEnumerable<HorarioGetPostPutDTO>> GetHorarios();
        //Get By Id Method
        Task<HorarioGetPostPutDTO> GetHorarioById(int id);
        //Post Method
        Task<bool> PostHorario(HorarioPostDTO horarioInsert);
        //Put Method
        Task<bool> PutHorario(HorarioGetPostPutDTO horarioUpdate);
        //Delete Method
        Task<bool> DeleteHorario(int id);
    }
}
