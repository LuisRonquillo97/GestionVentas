using AutoMapper;
using Controladores.Data;
using Modelos.Entities;
using System.Collections.Generic;

namespace Controladores.Mapper
{
    public class UsuarioMapper
    {
        //configuramos el automapper para pasar métodos de un objeto a otro.
        public IConfigurationProvider config = new MapperConfiguration(cfg =>
           cfg.CreateMap<UsuariosEntity, UsuariosData>()
            .ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id))
            .ForMember(dest => dest.Nombre, act => act.MapFrom(src => src.Nombre))
            .ForMember(dest => dest.NombreUsuario, act => act.MapFrom(src => src.NombreUsuario))
            .ForMember(dest => dest.Contraseña, act => act.MapFrom(src => src.Contraseña))
       );
        //método para mapear de un objeto del modelo a uno del controlador.
        public UsuariosData Map(UsuariosEntity origen)
        {
            var mapper = new AutoMapper.Mapper(config);
            return mapper.Map<UsuariosEntity, UsuariosData>(origen);
        }
        //lo mismo pero para listas.
        public List<UsuariosData> MapList(List<UsuariosEntity> origenList)
        {
            var mapper = new AutoMapper.Mapper(config);
            return mapper.Map<List<UsuariosEntity>, List<UsuariosData>>(origenList);
        }
    }
}
