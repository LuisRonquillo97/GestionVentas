using AutoMapper;
using Datos.Data;
using Datos.Interfaces;
using Modelos.Entities;
using System;
using System.Collections.Generic;

namespace Datos.Mapper
{
    public class EncabezadosNotaMapper : IMapper<EncabezadosNotaData, EncabezadoNotaEntity>
    {
        public IConfigurationProvider config = new MapperConfiguration(cfg =>
           cfg.CreateMap<EncabezadoNotaEntity, EncabezadosNotaData>()
            .ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id))
            .ForMember(dest => dest.FechaCreado, act => act.MapFrom(src => src.FechaCreado))
            .ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id))
            .ForMember(dest => dest.IdCliente, act => act.MapFrom(src => src.IdCliente))
            .ForMember(dest => dest.IdTipoPago, act => act.MapFrom(src => src.IdTipoPago))
            .ForMember(dest => dest.Status, act => act.MapFrom(src => src.Status))
            .ForMember(dest => dest.Comentario, act => act.MapFrom(src => src.Comentario))
            .ForPath(dest => dest.Cliente.Id, act => act.MapFrom(src => src.Cliente.Id))
            .ForPath(dest => dest.Cliente.Direccion, act => act.MapFrom(src => src.Cliente.Direccion))
            .ForPath(dest => dest.Cliente.NombreCompleto, act => act.MapFrom(src => src.Cliente.NombreCompleto))
            .ForPath(dest => dest.Cliente.Rfc, act => act.MapFrom(src => src.Cliente.Rfc))
            .ForPath(dest => dest.DetalleNotas, act => act.MapFrom(src => src.DetalleNotas))
            .ForPath(dest => dest.TipoPago.Id, act => act.MapFrom(src => src.TipoPago.Id))
            .ForPath(dest => dest.TipoPago.Descripcion, act => act.MapFrom(src => src.TipoPago.Descripcion))
       );
        public EncabezadosNotaData Map(EncabezadoNotaEntity origen)
        {
            var mapper = new AutoMapper.Mapper(config);
            return mapper.Map<EncabezadoNotaEntity, EncabezadosNotaData>(origen);
        }

        public List<EncabezadosNotaData> MapList(List<EncabezadoNotaEntity> origen)
        {
            var mapper = new AutoMapper.Mapper(config);
            return mapper.Map<List<EncabezadoNotaEntity>, List<EncabezadosNotaData>>(origen);
        }
    }
}
