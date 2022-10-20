using Talleres.Domain.Models.DTOs.GenreralDTOs;
using Talleres.Domain.Models.DTOs.GetDTOs;
using Talleres.Domain.Models.DTOs.PostDTO;

namespace Talleres.API.Repository
{
    public interface ITallerRepository
    {
        //Get Method
        Task<IEnumerable<TallerDTO>> GetTalleres();
        //Get By Id Method
        Task<TallerDTO> GetTallerById(int id);
        //Post Method
        Task<bool>PostTaller(TallerPostDTO tallerInsert);
        //Put Method
        Task<bool> PutTaller(TallerDTO horarioTaller);
        //Delete Method
        Task<bool> DeleteTaller(int id);
        Task<bool> verifyExistence(string nombre);
    }
}
