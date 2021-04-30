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
            .ForPath(dest=>dest.Articulo.Id,act=>act.MapFrom(src=>src.Articulo.Id))
            .ForPath(dest=>dest.Articulo.Descripcion,act=>act.MapFrom(src=>src.Articulo.Descripcion))
            .ForPath(dest=>dest.Articulo.Existencia,act=>act.MapFrom(src=>src.Articulo.Existencia))
            .ForPath(dest=>dest.Articulo.Impuesto,act=>act.MapFrom(src=>src.Articulo.Impuesto))
            .ForPath(dest=>dest.Articulo.PrecioVenta,act=>act.MapFrom(src=>src.Articulo.PrecioVenta))
       );

        public IConfigurationProvider datagridVentasConfig = new MapperConfiguration(mcf =>
            mcf.CreateMap<DetalleNotaEntity, DgvDetalleNota>()
            .ForMember(dest => dest.Articulo, act => act.MapFrom(src => src.Articulo.Descripcion))
            .ForMember(dest => dest.Cantidad, act => act.MapFrom(src => src.Cantidad))
            .ForMember(dest => dest.IdArticulo, act => act.MapFrom(src => src.IdArticulo))
            .ForMember(dest => dest.PrecioVenta, act => act.MapFrom(src => src.PrecioVenta))
            .ForMember(dest => dest.IdDetalleNota, act => act.MapFrom(src => src.Id.Value))
        );

        public IConfigurationProvider ventasConfigDatagrid = new MapperConfiguration(mcf =>
            mcf.CreateMap<DgvDetalleNota, DetalleNotaEntity>()
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

        public List<DgvDetalleNota> MapDgvVentas(List<DetalleNotaEntity> origen)
        {
            var mapper = new AutoMapper.Mapper(datagridVentasConfig);
            var dgvList = mapper.Map<List<DetalleNotaEntity>, List<DgvDetalleNota>>(origen);
            dgvList.ForEach(x => x.Total = x.Cantidad * x.PrecioVenta);
            return dgvList;
        }

        public List<DetalleNotaEntity> MapDgvVentas(List<DgvDetalleNota> origen)
        {
            var mapper = new AutoMapper.Mapper(datagridVentasConfig);
            return mapper.Map<List<DgvDetalleNota>, List<DetalleNotaEntity>>(origen);
        }

        public List<DetalleNotaEntity> MapList(List<DgvDetalleNota> origen)
        {
            var mapper = new AutoMapper.Mapper(ventasConfigDatagrid);
            return mapper.Map<List<DgvDetalleNota>, List<DetalleNotaEntity>>(origen);
        }
    }
}
