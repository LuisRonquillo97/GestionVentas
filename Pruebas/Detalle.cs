using Controladores.Catalogos;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pruebas
{
    public class Detalle
    {
        DetallesNotaCatalogoController detallesCat = new DetallesNotaCatalogoController();
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Agregar()
        {
            Assert.AreEqual("Detalle de nota agregada correctamente.", detallesCat.Agregar("3","1","1","115.53"));
        }
        [Test]
        public void Modificar()
        {
            Assert.AreEqual("Detalle de nota modificada correctamente.", detallesCat.Modificar("1","10", "2", "2", "1000.11"));
        }
        [Test]
        public void Eliminar()
        {
            Assert.AreEqual("Detalle de nota eliminada correctamente.", detallesCat.Desactivar("1"));
        }
        [Test]
        public void Buscar()
        {
            var obtenidos = detallesCat.Listar("", "", "", "", "").Count;
            Assert.GreaterOrEqual(obtenidos, 1, $"Elementos obtenidos: {obtenidos}. Se esperaba uno o más de uno.");
        }
        [Test]
        public void BuscarConFiltros()
        {
            var obtenidos = detallesCat.Listar("1", "10", "2", "2", "1000.11").Count;
            Assert.AreEqual(1, obtenidos, $"Elementos obtenidos: {obtenidos}. Se debe recibir uno.");
        }
    }
}
