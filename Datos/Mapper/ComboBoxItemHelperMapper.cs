using AutoMapper;
using Datos.Helpers;
using Datos.Interfaces;
using Modelos.Entities;
using System.Collections.Generic;

namespace Datos.Mapper
{
    public class ComboBoxItemHelperMapper : IMapper<ComboBoxItem, TipoPagoEntity>
    {
        public IConfigurationProvider config = new MapperConfiguration(cfg =>
           cfg.CreateMap<TipoPagoEntity, ComboBoxItem>()
            .ForMember(dest => dest.Text, act => act.MapFrom(src => src.Descripcion))
            .ForMember(dest => dest.Value, act => act.MapFrom(src => src.Id))
       );
        public ComboBoxItem Map(TipoPagoEntity origen)
        {
            var mapper = new AutoMapper.Mapper(config);
            return mapper.Map<TipoPagoEntity, ComboBoxItem>(origen);
        }

        public List<ComboBoxItem> MapList(List<TipoPagoEntity> origen)
        {
            var mapper = new AutoMapper.Mapper(config);
            return mapper.Map<List<TipoPagoEntity>, List<ComboBoxItem>>(origen);
        }
    }
}
