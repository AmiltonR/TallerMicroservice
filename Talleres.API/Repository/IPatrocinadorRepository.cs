using Talleres.Domain.Models.DTOs.Patrocinador;
using Talleres.Domain.Models.DTOs.Publico;

namespace Talleres.API.Repository
{
    public interface IPatrocinadorRepository
    {
        Task<IEnumerable<PatrocinadorGetPutDTO>> GetPatrocinadores();
        //Get By Id Method
        Task<PatrocinadorGetPutDTO> GetPatrocinadorById(int id);
        //Post Method
        Task<bool> PostPatrocinador(PatrocinadorPostDTO patrocinadorInsert);
        //Put Method
        Task<bool> PutPatrocinador(PatrocinadorGetPutDTO patrocinadorUpdate);
        //Delete Method
        Task<bool> DeletePatrocinador(int id);
    }
}
