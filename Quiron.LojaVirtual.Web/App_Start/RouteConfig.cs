using System.Drawing;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Routing;

namespace Quiron.LojaVirtual.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //Rota 1 - Resultado = /
            routes.MapRoute(
                name: null,
                url: "",
                defaults: new
                    {
                        controller = "Vitrine",
                        action = "ListaProdutos",
                        categoria = (string)null,
                        pagina = 1
                    }
                );

            //Rota 2 - Resultado = /Pagina
            routes.MapRoute(
              null,
              "Pagina{pagina}",
              new
              {
                  controller = "Vitrine",
                  action = "ListaProdutos",
                  categoria = (string)null
              },
              new { pagina = @"\d+" });

            //Rota 3 - Resultado = /Categoria
            routes.MapRoute(
                null,
                "{categoria}",
                new
                    {
                        controller = "Vitrine",
                        action = "ListaProdutos",
                        pagina = 1
                    }
                );

            //Rota 4 - Resultado = /Categoria/Pagina
            routes.MapRoute(
                null,
                "{categoria}Pagina{pagina}",
                new
                    {
                        controller = "Vitrine",
                        action = "ListaProdutos"
                    },
                new { pagina = @"\d+" }
                );


            //Rota Padrão
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Vitrine", action = "ListaProdutos", id = UrlParameter.Optional }
            );
        }
    }
}
