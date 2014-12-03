using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quiron.LojaVirtual.Dominio.Entidades;


namespace Quiron.LojaVirtual.UnitTest
{
    [TestClass]
    public class TesteCarrinhoCompras
    {
        //teste de adicionar produtos no carrinho
        [TestMethod]
        public void AdicionarItemCarrinho()
        {

            Carrinho carrinho = new Carrinho();
            Produto produto1 = new Produto
            {
                ProdutoId = 1,
                Nome = "teste1"
            };
            Produto produto2 = new Produto
            {
                ProdutoId = 2,
                Nome = "teste2"
            };

            carrinho.Adicionar(produto1, 2);

            carrinho.Adicionar(produto2, 1);

            //act
            List<ItemCarrinho> _itemCarrinhos = carrinho.ListarItemCarrinhos().ToList();

            //assert
            Assert.AreEqual(_itemCarrinhos[0].Produto, produto1);
            Assert.AreEqual(_itemCarrinhos[1].Produto, produto2);
            Assert.AreEqual(_itemCarrinhos.Count, 2);
        }

        //Teste de produtos e quantidades
        [TestMethod]
        public void AdicionarProdutoExistenteParaCarrinho()
        {
            //Arrange - criação dos produtos
            Produto produto1 = new Produto
            {
                ProdutoId = 1,
                Nome = "Teste 1"
            };

            Produto produto2 = new Produto
            {
                ProdutoId = 2,
                Nome = "Teste 2"
            };

            //Arrange

            Carrinho carrinho = new Carrinho();

            carrinho.Adicionar(produto1, 1);

            carrinho.Adicionar(produto2, 1);

            carrinho.Adicionar(produto1, 10);

            //Act
            ItemCarrinho[] resultado = carrinho.ListarItemCarrinhos()
                .OrderBy(c => c.Produto.ProdutoId).ToArray();


            Assert.AreEqual(resultado.Length, 2);

            Assert.AreEqual(resultado[0].Quantidade, 11);

            Assert.AreEqual(resultado[1].Quantidade, 1);
        }

        [TestMethod]
        public void remover()
        {
            //Arrange - criação dos produtos
            Produto produto1 = new Produto
            {
                ProdutoId = 1,
                Nome = "Teste 1"
            };

            Produto produto2 = new Produto
            {
                ProdutoId = 2,
                Nome = "Teste 2"
            };

            //Arrange

            Carrinho carrinho = new Carrinho();

            carrinho.Adicionar(produto1, 1);

            carrinho.Adicionar(produto2, 1);

            carrinho.Adicionar(produto2, 5);

            carrinho.Adicionar(produto1, 10);

            carrinho.Remover(produto1);
            ItemCarrinho[] resultado = carrinho.ListarItemCarrinhos().ToArray();

            Assert.AreEqual(resultado.Length,1);

        }

        [TestMethod]
        public void CalcularValorTotal()
        {
            //Arrange - criação dos produtos
            Produto produto1 = new Produto
            {
                ProdutoId = 1,
                Nome = "Teste 1",
                Preco = 100M
               
            };

            Produto produto2 = new Produto
            {
                ProdutoId = 2,
                Nome = "Teste 2",
                Preco = 50M
            };

            //Arrange

            Carrinho carrinho = new Carrinho();

            carrinho.Adicionar(produto1, 1);

            carrinho.Adicionar(produto2, 2);

            carrinho.Adicionar(produto2,3);

            decimal resultado = carrinho.ObterValorTotal();

            Assert.AreEqual(resultado,350M);
        }

        [TestMethod]
        public void LimparCarrinho()
        {
            //Arrange - criação dos produtos
            Produto produto1 = new Produto
            {
                ProdutoId = 1,
                Nome = "Teste 1",
                Preco = 100M

            };

            Produto produto2 = new Produto
            {
                ProdutoId = 2,
                Nome = "Teste 2",
                Preco = 50M
            };

            //Arrange

            Carrinho carrinho = new Carrinho();

            carrinho.Adicionar(produto1, 1);

            carrinho.Adicionar(produto2, 2);

            carrinho.Adicionar(produto2, 3);

            carrinho.LimparCarrinho();

            ItemCarrinho[] itemCarrinhos = carrinho.ListarItemCarrinhos().ToArray();

            Assert.AreEqual(itemCarrinhos.Length,0);
        }

    }
}
