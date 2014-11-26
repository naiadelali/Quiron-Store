using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Quiron.LojaVirtual.Web.Models;

namespace Quiron.LojaVirtual.Web.HtmlHelpers
{
    public static class PaginacaoHelper
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html, Paginacao paginacao, Func<int, string> PaginacaoUrl)
        {
            StringBuilder resultado = new StringBuilder();

            for (int i = 1; i <= paginacao.TotalPagina; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.Attributes.Add("href", PaginacaoUrl(i));

                if (paginacao.PaginaAtual == i)
                {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-primary");
                }
                tag.AddCssClass("btn btn-default");
                tag.InnerHtml=i.ToString();
                resultado.Append(tag);

            }

            return MvcHtmlString.Create(resultado.ToString());
        }
    }
}