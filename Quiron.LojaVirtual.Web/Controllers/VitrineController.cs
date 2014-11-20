﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quiron.LojaVirtual.Dominio.Repositorio;

namespace Quiron.LojaVirtual.Web.Controllers
{
    public class VitrineController : Controller
    {
        private ProdutoRepositorio _repositorio;
        private int produtosPorPagina = 3;
        //
        // GET: /Vitrine/
        public ActionResult ListaProdutos(int pagina = 1)
        {
            _repositorio = new ProdutoRepositorio();
            var produto = _repositorio.Produtos
                .OrderBy(p => p.Nome)
                .Skip((pagina - 1)*produtosPorPagina)
                .Take(produtosPorPagina);

            return View(produto);
        }
	}
}