using System;
using System.Collections.Generic;
using System.Text;

namespace Datos.Interfaces
{
    public interface IMapper<Data,Entity>
    {
        public Data Map(Entity origen);
        public List<Data> MapList(List<Entity> origen);
    }
}
