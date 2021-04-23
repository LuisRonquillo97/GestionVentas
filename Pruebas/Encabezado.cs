using Controladores.Catalogos;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pruebas
{
    public class Encabezado
    {
        EncabezadosNotaCatalogoController encabezadosCat = new EncabezadosNotaCatalogoController();
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Agregar()
        {
            Assert.AreEqual("Encabezado de nota agregado correctamente.", encabezadosCat.Agregar("",DateTime.Now,"4","2","Activo"));
        }
        [Test]
        public void Modificar()
        {
            Assert.AreEqual("Encabezado de nota modificado correctamente.", encabezadosCat.Modificar("1", "modificado", DateTime.Now.AddDays(1), "5", "1", "Enviado"));
        }
        [Test]
        public void Eliminar()
        {
            Assert.AreEqual("Encabezado de nota eliminado correctamente.", encabezadosCat.Desactivar("1"));
        }
        [Test]
        public void Buscar()
        {
            var obtenidos = encabezadosCat.Listar("","",null,"","","").Count;
            Assert.GreaterOrEqual(obtenidos, 1, $"Elementos obtenidos: {obtenidos}. Se esperaba uno o más de uno.");
        }
        [Test]
        public void BuscarConFiltros()
        {
            var obtenidos = encabezadosCat.Listar("1", "modificado", DateTime.Now.AddDays(1), "5", "1", "Enviado").Count;
            Assert.AreEqual(1, obtenidos, $"Elementos obtenidos: {obtenidos}. Se debe recibir uno.");
        }
    }
}
