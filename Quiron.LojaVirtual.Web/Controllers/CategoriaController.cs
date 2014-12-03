using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Quiron.LojaVirtual.Dominio.Repositorio;

namespace Quiron.LojaVirtual.Web.Controllers
{
    public class CategoriaController : Controller
    {
        /*- Faça um contoller chamado Categoria que possua uma PartialViewResult chamada Menu.
          - Faça uma busca nas categorias da classe Produto sem repetições.*/
        private ProdutoRepositorio _repositorio;
        public PartialViewResult Menu(string categoria = null)
        {
            _repositorio = new ProdutoRepositorio();
            ViewBag.CategoriaSelecionada = categoria;
            var menu = _repositorio.Produtos
                .Select(c => c.Categoria.Trim())
                .Distinct()
                .OrderBy(c => c);

            return PartialView(menu);

        }
	}
}