using AutoMapper;
using Datos.Data;
using Datos.Interfaces;
using Modelos.Entities;
using System.Collections.Generic;

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

        public IConfigurationProvider datagridVentasConfig = new MapperConfiguration(mcf =>
            mcf.CreateMap<DetalleNotaEntity, DgvPuntoVenta>()
            .ForMember(dest => dest.Articulo, act => act.MapFrom(src => src.Articulo.Descripcion))
            .ForMember(dest => dest.Cantidad, act => act.MapFrom(src => src.Cantidad))
            .ForMember(dest => dest.IdArticulo, act => act.MapFrom(src => src.IdArticulo))
            .ForMember(dest => dest.PrecioVenta, act => act.MapFrom(src => src.PrecioVenta))
        );

        public IConfigurationProvider ventasConfigDatagrid = new MapperConfiguration(mcf =>
            mcf.CreateMap<DgvPuntoVenta, DetalleNotaEntity>()
            .ForMember(dest => dest.Cantidad, act => act.MapFrom(src => src.Cantidad))
            .ForMember(dest => dest.IdArticulo, act => act.MapFrom(src => src.IdArticulo))
            .ForMember(dest => dest.PrecioVenta, act => act.MapFrom(src => src.PrecioVenta))
            .ForMember(dest => dest.Articulo, act => act.Ignore())
            .ForMember(dest => dest.EncabezadoNota, act => act.Ignore())
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

        public List<DgvPuntoVenta> MapDgvVentas(List<DetalleNotaEntity> origen)
        {
            var mapper = new AutoMapper.Mapper(datagridVentasConfig);
            return mapper.Map<List<DetalleNotaEntity>, List<DgvPuntoVenta>>(origen);
        }

        public List<DetalleNotaEntity> MapDgvVentas(List<DgvPuntoVenta> origen)
        {
            var mapper = new AutoMapper.Mapper(datagridVentasConfig);
            return mapper.Map<List<DgvPuntoVenta>, List<DetalleNotaEntity>>(origen);
        }

        public List<DetalleNotaEntity> MapList(List<DgvPuntoVenta> origen)
        {
            var mapper = new AutoMapper.Mapper(ventasConfigDatagrid);
            return mapper.Map<List<DgvPuntoVenta>, List<DetalleNotaEntity>>(origen);
        }
    }
}
