using AutoMapper;
using Datos.Data;
using Datos.Interfaces;
using Modelos.Entities;
using System.Collections.Generic;

namespace Datos.Mapper
{
    public class EncabezadosNotaMapper : IMapper<EncabezadosNotaData, EncabezadoNotaEntity>
    {
        public IConfigurationProvider config = new MapperConfiguration(cfg =>
           cfg.CreateMap<EncabezadosNotaData, EncabezadoNotaEntity > ()
            .ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id))
            .ForMember(dest => dest.FechaCreado, act => act.MapFrom(src => src.FechaCreado))
            .ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id))
            .ForMember(dest => dest.IdCliente, act => act.MapFrom(src => src.IdCliente))
            .ForMember(dest => dest.IdTipoPago, act => act.MapFrom(src => src.IdTipoPago))
            .ForMember(dest => dest.Status, act => act.MapFrom(src => src.Status))
            .ForMember(dest => dest.Comentario, act => act.MapFrom(src => src.Comentario))
        );
        public IConfigurationProvider datagridConfig = new MapperConfiguration(mcf =>
            mcf.CreateMap<EncabezadoNotaEntity, DgvEncabezadoNota>()
            .ForMember(dest => dest.Cliente, act => act.MapFrom(src => src.Cliente.NombreCompleto))
            .ForMember(dest=>dest.Comentario,act=>act.MapFrom(src=>src.Comentario))
            .ForMember(dest=>dest.FechaCreado,act=>act.MapFrom(src=>src.FechaCreado))
            .ForMember(dest=>dest.Id,act=>act.MapFrom(src=>src.Id))
            .ForMember(dest=>dest.IdCliente,act=>act.MapFrom(src=>src.IdCliente))
            .ForMember(dest=>dest.IdTipoPago,act=>act.MapFrom(src=>src.IdTipoPago))
            .ForMember(dest=>dest.Status,act=>act.MapFrom(src=>src.Status))
            .ForMember(dest=>dest.TipoPago,act=>act.MapFrom(src=>src.TipoPago.Descripcion))
        );
        public EncabezadosNotaData Map(EncabezadoNotaEntity origen)
        {
            AutoMapper.Mapper mapper = new AutoMapper.Mapper(config);
            return mapper.Map<EncabezadoNotaEntity, EncabezadosNotaData>(origen);
        }
        public EncabezadoNotaEntity Map(EncabezadosNotaData origen)
        {
            AutoMapper.Mapper mapper = new AutoMapper.Mapper(config);
            return mapper.Map<EncabezadosNotaData, EncabezadoNotaEntity>(origen);
        }
        public List<EncabezadosNotaData> MapList(List<EncabezadoNotaEntity> origen)
        {
            AutoMapper.Mapper mapper = new AutoMapper.Mapper(config);
            return mapper.Map<List<EncabezadoNotaEntity>, List<EncabezadosNotaData>>(origen);
        }
        public List<DgvEncabezadoNota> MapListDatagridEncabezado(List<EncabezadoNotaEntity> origen)
        {
            AutoMapper.Mapper mapper = new AutoMapper.Mapper(datagridConfig);
            return mapper.Map<List<EncabezadoNotaEntity>, List<DgvEncabezadoNota>>(origen);
        }
        public DgvEncabezadoNota MapDatagridEncabezado(EncabezadoNotaEntity origen)
        {
            AutoMapper.Mapper mapper = new AutoMapper.Mapper(datagridConfig);
            return mapper.Map<EncabezadoNotaEntity, DgvEncabezadoNota>(origen);
        }
    }
}
