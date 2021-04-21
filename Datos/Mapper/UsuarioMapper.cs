using AutoMapper;
using Datos.Data;
using Modelos.Entities;
using System.Collections.Generic;

namespace Datos.Mapper
{
    /*
     * AutoMapper es un NuGet que permite pasar parámetros de un objeto A a un Objeto B, aunque no sean de la misma clase
     * es muy útil si tenemos que hacer lo anterior muchas veces, evitamos escribir tanto código.
     */
    public class UsuarioMapper
    {
        /*
         * Primero, tenemos que configurar, desde que tipo de objeto A, vamos a pasar parámetos al objeto B.
         * En este caso, de UsuariosEntity, pasaremos parámetros a UsuariosData.
         * puede parecer confuso ya que se llaman iguales, pero los lambdas te dicen cuál es el objeto destino, y cual el objeto actuall
         * osea, el objeto de origen.
         */
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
        //método para mapear de una lista de objetos del modelo a uno del controlador.
        public List<UsuariosData> MapList(List<UsuariosEntity> origenList)
        {
            var mapper = new AutoMapper.Mapper(config);
            return mapper.Map<List<UsuariosEntity>, List<UsuariosData>>(origenList);
        }
    }
}
