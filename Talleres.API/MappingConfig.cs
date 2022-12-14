using AutoMapper;
using Talleres.Domain.DTOs;
using Talleres.Domain.Entities;
using Talleres.Domain.Models.DTOs;
using Talleres.Domain.Models.DTOs.Patrocinador;
using Talleres.Domain.Models.DTOs.Publico;

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

                config.CreateMap<TallerParticipante, tallerParticipantesUsuariosDTO>();

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

                //TALER PROGRAMACION
                //GET
                config.CreateMap<TallerProgramacion, TallerProgramacionGetDTO>();
                config.CreateMap<TallerProgramacionGetDTO, TallerProgramacion>();
                //POST
                config.CreateMap<TallerProgramacion, TallerProgramacionPostDTO>();
                config.CreateMap<TallerProgramacionPostDTO, TallerProgramacion>();
                //PUT
                config.CreateMap<TallerProgramacion, TallerProgramacionPutDTO>();
                config.CreateMap<TallerProgramacionPutDTO, TallerProgramacion>();
                //PUT
                config.CreateMap<TallerProgramacion, TallerProgramacionDeleteDTO>();
                config.CreateMap<TallerProgramacionDeleteDTO, TallerProgramacion>();
                //PUBLICO
                //GET
                config.CreateMap<Publico, PublicGetPutDTO>();
                config.CreateMap<PublicGetPutDTO, Publico>();
                //POST
                config.CreateMap<Publico, PublicoPostDTO>();
                config.CreateMap<PublicoPostDTO, Publico>();
                //PUT
                config.CreateMap<Publico, PublicGetPutDTO>();
                config.CreateMap<PublicGetPutDTO, Publico>();
                //PATROCINADOR
                //GET
                config.CreateMap<Patrocinador, PatrocinadorGetPutDTO>();
                config.CreateMap<PatrocinadorGetPutDTO, Patrocinador>();
                //POST
                config.CreateMap<Patrocinador, PatrocinadorPostDTO>();
                config.CreateMap<PatrocinadorPostDTO, Patrocinador>();
                //PUT
                config.CreateMap<Patrocinador, PatrocinadorGetPutDTO>();
                config.CreateMap<PatrocinadorGetPutDTO, Patrocinador>();

                //SOLICITUD
                //POST
                config.CreateMap<Solicitud, SolicitudPostDTO>();
                config.CreateMap<SolicitudPostDTO, Solicitud>();
                //GET
                config.CreateMap<Solicitud, SolicitudGetDTO>();
                config.CreateMap<SolicitudGetDTO, Solicitud>();

                //NOTIFICACIONES
                config.CreateMap<Notificacion, NotificacionGetDTO>();
                config.CreateMap<NotificacionGetDTO, Notificacion>();
            });
            return mappingConfig;
        }
    }
}
