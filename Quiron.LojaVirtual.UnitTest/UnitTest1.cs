using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Quiron.LojaVirtual.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Take()
        {
            int[] numeros = {1, 5, 6, 9, 8, 4, 7, 10, 15, 20};

            var resultado = from num in numeros.Take(5) select num;

            int[] teste = { 1, 5, 6, 9, 8 };

            CollectionAssert.AreEqual(resultado.ToArray(),teste);
        }

        [TestMethod]
        public void Skip()
        {
            int[] numeros = { 1, 5, 6, 9, 8, 4, 7, 10, 15, 20 };
            var resultado = from num in numeros.Take(5).Skip(3) select num;

            int[] teste = {9, 8};
            CollectionAssert.AreEqual(resultado.ToArray(),teste);
        }
    }
}
