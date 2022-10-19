using Talleres.Domain.Models.DTOs;
using Talleres.Domain.Models.DTOs.GetDTOs;
using Talleres.Domain.Models.DTOs.PostDTO;

namespace Talleres.API.Repository
{
    public interface ITallerRepository
    {
        //Get Method
        Task<IEnumerable<TallerGetDTO>> GetTalleres();
        //Get By Id Method
        Task<TallerGetDTO> GetTaller(int id);
        //Post Method
        Task<bool>PostTaller(TallerPostDTO tallerInsert);
        //Put Method
        Task<bool> PutTaller(TallerGetDTO horarioTaller);
        //Delete Method
        Task<bool> DeleteTaller(int id);
        Task<bool> verifyExistence(string nombre);
    }
}
