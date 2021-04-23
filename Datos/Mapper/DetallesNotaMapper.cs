using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Datos.Data;
using Datos.Interfaces;
using Modelos.Entities;

namespace Datos.Mapper
{
    public class DetallesNotaMapper : IMapper<DetallesNotaData, DetalleNotaEntity>
    {
        public IConfigurationProvider config = new MapperConfiguration(cfg =>
           cfg.CreateMap<DetalleNotaEntity, DetallesNotaData>()
            .ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id))
            .ForMember(dest => dest.IdArticulo, act => act.MapFrom(src => src.IdArticulo))
            .ForMember(dest => dest.IdEncabezadoNota, act => act.MapFrom(src => src.IdEncabezadoNota))
            .ForMember(dest => dest.PrecioVenta, act => act.MapFrom(src => src.PrecioVenta))
       );
        public DetallesNotaData Map(DetalleNotaEntity origen)
        {
            var mapper = new AutoMapper.Mapper(config);
            return mapper.Map<DetalleNotaEntity, DetallesNotaData>(origen);
        }

        public List<DetallesNotaData> MapList(List<DetalleNotaEntity> origen)
        {
            var mapper = new AutoMapper.Mapper(config);
            return mapper.Map<List<DetalleNotaEntity>, List<DetallesNotaData>>(origen);
        }
    }
}
