﻿using System.Linq;
using System.Web.Mvc;
using Quiron.LojaVirtual.Dominio.Entidades;
using Quiron.LojaVirtual.Dominio.Repositorio;
using Quiron.LojaVirtual.Web.Models;

namespace Quiron.LojaVirtual.Web.Controllers
{
    public class VitrineController : Controller
    {
        private ProdutoRepositorio _repositorio;
        private int produtosPorPagina = 8;
        //
        // GET: /Vitrine/
        public ViewResult ListaProdutos(string categoria, int pagina = 1)
        {
            _repositorio = new ProdutoRepositorio();
            ProdutosViewModel model = new ProdutosViewModel
            {
                Produtos = _repositorio.Produtos
                    .Where(p => p.Categoria == null || p.Categoria.Trim() == categoria)
                    .OrderBy(p => p.Nome)
                    .Skip((pagina - 1) * produtosPorPagina)
                    .Take(produtosPorPagina),
                Paginacao = new Paginacao
                {
                    PaginaAtual = pagina,
                    ItensPorPagina = produtosPorPagina,
                    ItemTotal = _repositorio.Produtos.Count()
                },
                CategoriaAtual = categoria

            };

            return View(model);
        }
    }
}