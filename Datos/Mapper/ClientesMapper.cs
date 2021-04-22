using System;
using System.Collections.Generic;
using System.Text;
using Datos.Interfaces;
using Datos.Data;
using Modelos.Entities;
using AutoMapper;

namespace Datos.Mapper
{
    public class ClientesMapper : IMapper<ClientesData, ClienteEntity>
    {
        public IConfigurationProvider config = new MapperConfiguration(cfg =>
           cfg.CreateMap<ClienteEntity, ClientesData>()
            .ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id))
            .ForMember(dest => dest.Direccion, act => act.MapFrom(src => src.Direccion))
            .ForMember(dest => dest.NombreCompleto, act => act.MapFrom(src => src.NombreCompleto))
            .ForMember(dest => dest.Rfc, act => act.MapFrom(src => src.Rfc))
       );
        public ClientesData Map(ClienteEntity origen)
        {
            var mapper = new AutoMapper.Mapper(config);
            return mapper.Map<ClienteEntity, ClientesData>(origen);
        }

        public List<ClientesData> MapList(List<ClienteEntity> origen)
        {
            var mapper = new AutoMapper.Mapper(config);
            return mapper.Map<List<ClienteEntity>, List<ClientesData>>(origen);
        }
    }
}
