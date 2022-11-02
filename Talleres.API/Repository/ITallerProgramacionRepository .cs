using Talleres.Domain.Models.DTOs;

namespace Talleres.API.Repository
{
    public interface ITallerProgramacionRepository
    {
        //Get Method
        //Trae todos los talleres
        Task<IEnumerable<TallerProgramacionGetDTO>> GetTalleres();
        //Get By Id Method
        Task<TallerProgramacionGetDTO> GetTallerById(int id);
        //Post Method
        Task<bool> PostTaller(TallerProgramacionPostDTO tallerInsert);
        //Put Method
        Task<bool> PutTaller(TallerProgramacionPutDTO tallerUpdate);
        //Delete Method
        Task<bool> DeleteTaller(int id);
        //Set inactive method --UPDATE
        Task<bool> SetInactive(int Id, int op);
        //Trae los talleres que están activos
        Task<IEnumerable<TallerProgramacionGetDTO>> GetActiveTalleres();
        //Traer el taller en el que está el usuario estudiante
        //si el taller está activo
        Task<TallerProgramacionGetEstudianteDTO> GetTallerByUser(int idUsuario);
        //Trae todos los talleres en donde está inscrito el usuario siendo estos activos e inactivos
        Task<IEnumerable<TallerProgramacionGetEstudianteDTO>> GetTalleresByUser(int idUsuario);
    }
}
