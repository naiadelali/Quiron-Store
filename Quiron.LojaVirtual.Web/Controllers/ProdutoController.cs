using System.Linq;
using System.Web.Mvc;
using Quiron.LojaVirtual.Dominio.Repositorio;

namespace Quiron.LojaVirtual.Web.Controllers
{
    public class ProdutoController : Controller
    {
        private ProdutoRepositorio _repositorio;
        //
        // GET: /Produto/
        public ActionResult Index()
        {
            _repositorio = new ProdutoRepositorio();

            var produtos = _repositorio.Produtos.Take(3);
            return View(produtos);
        }
	}
}