using AutoMapper;
using Datos.Data;
using Modelos.Entities;
using System.Collections.Generic;
using Datos.Interfaces;

namespace Datos.Mapper
{
    public class ArticulosMapper:IMapper<ArticulosData,ArticulosEntity>
    {
        public IConfigurationProvider config = new MapperConfiguration(cfg =>
           cfg.CreateMap<ArticulosEntity, ArticulosData>()
            .ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id))
            .ForMember(dest => dest.Descripcion, act => act.MapFrom(src => src.Descripcion))
            .ForMember(dest => dest.Existencia, act => act.MapFrom(src => src.Existencia))
            .ForMember(dest => dest.Impuesto, act => act.MapFrom(src => src.Impuesto))
            .ForMember(dest => dest.PrecioVenta, act => act.MapFrom(src => src.PrecioVenta))
       );
        //método para mapear de un objeto del modelo a uno del controlador.
        public ArticulosData Map(ArticulosEntity origen)
        {
            var mapper = new AutoMapper.Mapper(config);
            return mapper.Map<ArticulosEntity, ArticulosData>(origen);
        }
        //método para mapear de una lista de objetos del modelo a uno del controlador.
        public List<ArticulosData> MapList(List<ArticulosEntity> origenList)
        {
            var mapper = new AutoMapper.Mapper(config);
            return mapper.Map<List<ArticulosEntity>, List<ArticulosData>>(origenList);
        }
    }
}
