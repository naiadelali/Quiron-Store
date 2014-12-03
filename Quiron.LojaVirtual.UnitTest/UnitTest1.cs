using System;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quiron.LojaVirtual.Web.Models;
using Quiron.LojaVirtual.Web.HtmlHelpers;

namespace Quiron.LojaVirtual.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Take()
        {
            int[] numeros = { 1, 5, 6, 9, 8, 4, 7, 10, 15, 20 };

            var resultado = from num in numeros.Take(5) select num;

            int[] teste = { 1, 5, 6, 9, 8 };

            CollectionAssert.AreEqual(resultado.ToArray(), teste);
        }

        [TestMethod]
        public void Skip()
        {
            int[] numeros = { 1, 5, 6, 9, 8, 4, 7, 10, 15, 20 };
            var resultado = from num in numeros.Take(5).Skip(3) select num;

            int[] teste = { 9, 8 };
            CollectionAssert.AreEqual(resultado.ToArray(), teste);
        }

        [TestMethod]
        public void TestarSeAPaginacaoEstaSendoGeradaCorretamente()
        {
            //Arrange
            HtmlHelper htmlHelper = null;
            var paginacao = new Paginacao
            {
                PaginaAtual = 2,
                ItemTotal = 28,
                ItensPorPagina = 10
            };

            Func<int, string> paginaUrl = i => "Pagina" + i;
            //Act
            MvcHtmlString resultado = htmlHelper.PageLinks(paginacao, paginaUrl);

            //Assert

            Assert.AreEqual(
           @"<a class=""btn btn-default"" href=""Pagina1"">1</a>"
           + @"<a class=""btn btn-default btn-primary selected"" href=""Pagina2"">2</a>"
           + @"<a class=""btn btn-default"" href=""Pagina3"">3</a>", resultado.ToString()
           );

        }

    
    }
}
