using Controladores.Catalogos;
using NUnit.Framework;

namespace Pruebas
{
    public class Clientes
    {
        ClientesCatalogoController clientesCat = new ClientesCatalogoController();
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Agregar()
        {
            Assert.AreEqual("Cliente agregado correctamente.", clientesCat.Agregar("calle 61 801", "Luis Eduardo Ronquillo Arroyo", "ROAL971129HVZNR"));
        }
        [Test]
        public void Modificar()
        {
            Assert.AreEqual("Cliente modificado correctamente.", clientesCat.Modificar("4","Modificado", "Luis Modificado Ronquillo Arroyo", "MODI971129HVZNR"));
        }
        [Test]
        public void Eliminar()
        {
            Assert.AreEqual("Cliente eliminado correctamente.", clientesCat.Desactivar("4"));
        }
        [Test]
        public void Buscar()
        {
            var obtenidos = clientesCat.Listar("", "", "", "").Count;
            Assert.GreaterOrEqual(obtenidos,1, $"Elementos obtenidos: {obtenidos}. Se esperaba uno o más de uno.");
        }
        [Test]
        public void BuscarConFiltros()
        {
            var obtenidos = clientesCat.Listar("4", "Modificado", "Luis Modificado Ronquillo Arroyo", "MODI971129HVZNR").Count;
            Assert.AreEqual(1, obtenidos, $"Elementos obtenidos: {obtenidos}. Se debe recibir uno.");
        }
    }
}