using Talleres.Domain.Models.DTOs;
using Talleres.Domain.Models.DTOs.Publico;

namespace Talleres.API.Repository
{
    public interface IPublicoRepository
    {
        Task<IEnumerable<PublicGetPutDTO>> GetPublicos();
        //Get By Id Method
        Task<PublicGetPutDTO> GetPublicoById(int id);
        //Post Method
        Task<bool> PostPublico(PublicoPostDTO publicoInsert);
        //Put Method
        Task<bool> PutPublico(PublicGetPutDTO publicoUpdate);
        //Delete Method
        Task<bool> DeletePublico(int id);
    }
}
