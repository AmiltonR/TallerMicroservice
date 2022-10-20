using AutoMapper;
using Talleres.Domain.DTOs;
using Talleres.Domain.Entities;
using Talleres.Domain.Models.DTOs.GenreralDTOs;
using Talleres.Domain.Models.DTOs.GetDTOs;
using Talleres.Domain.Models.DTOs.PostDTO;

namespace Talleres.API
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<TallerParticipanteGetDTO, TallerParticipante>();
                config.CreateMap<TallerParticipante, TallerParticipanteGetDTO>();

                //HORARIOS
                //--GET Y PUT
                config.CreateMap<Horario, HorarioGetPostPutDTO>();
                config.CreateMap<HorarioGetPostPutDTO, Horario>();
                //POST
                config.CreateMap<Horario, HorarioPostDTO>();
                config.CreateMap<HorarioPostDTO, Horario>();

                //TALLERES
                //GET
                config.CreateMap<Taller, TallerDTO>();
                config.CreateMap<TallerDTO, Taller>();
                //POST
                config.CreateMap<Taller, TallerPostDTO>();
                config.CreateMap<TallerPostDTO, Taller>();
            });
            return mappingConfig;
        }
    }
}
