using Datos.Interfaces;
using Datos.Data;
using Modelos.Entities;
using System.Collections.Generic;
using AutoMapper;

namespace Datos.Mapper
{
    public class TiposPagoMapper : IMapper<TiposPagoData, TipoPagoEntity>
    {
        public IConfigurationProvider config = new MapperConfiguration(cfg =>
           cfg.CreateMap<TipoPagoEntity, TiposPagoData>()
            .ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id))
            .ForMember(dest => dest.Descripcion, act => act.MapFrom(src => src.Descripcion))
       );
        public TiposPagoData Map(TipoPagoEntity origen)
        {
            return new AutoMapper.Mapper(config).Map<TipoPagoEntity, TiposPagoData>(origen);
        }

        public List<TiposPagoData> MapList(List<TipoPagoEntity> origen)
        {
            return new AutoMapper.Mapper(config).Map<List<TipoPagoEntity>, List<TiposPagoData>>(origen);
        }
    }
}
