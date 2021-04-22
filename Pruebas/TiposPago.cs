using Controladores.Catalogos;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pruebas
{
    class TiposPago
    {
        TiposPagoCatalogoController tiposPagoCat = new TiposPagoCatalogoController();
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Agregar()
        {
            string result = tiposPagoCat.Agregar("Efectivo");
            Assert.AreEqual("Tipo de pago agregado correctamente.", result, $"el mensaje que llegó fue:{result}.\n no era lo esperado.");
        }
        [Test]
        public void Modificar()
        {
            string result = tiposPagoCat.Modificar("1", "Crédito");
            Assert.AreEqual("Tipo de pago modificado correctamente.", result,$"el mensaje que llegó fue:{result}.\n no era lo esperado.");
        }
        [Test]
        public void Eliminar()
        {
            string result = tiposPagoCat.Desactivar("1");
            Assert.AreEqual("Tipo de pago eliminado correctamente.", result, $"el mensaje que llegó fue:{result}.\n no era lo esperado.");
        }
        [Test]
        public void Buscar()
        {
            var obtenidos = tiposPagoCat.Listar("", "").Count;
            Assert.GreaterOrEqual(obtenidos,1 , $"Elementos obtenidos: {obtenidos}. Se esperaba uno o más de uno.");
        }
        [Test]
        public void BuscarConFiltros()
        {
            var obtenidos = tiposPagoCat.Listar("1", "Crédito").Count;
            Assert.AreEqual(1, obtenidos, $"Elementos obtenidos: {obtenidos}. Se debe recibir uno.");
        }
    }
}
