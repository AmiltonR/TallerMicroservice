using Talleres.Domain.Models.DTOs;

namespace Talleres.API.Repository
{
    public interface ITallerProgramacionRepository
    {
        //Get Method
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
        Task<bool> SetInactive(int id);
    }
}
