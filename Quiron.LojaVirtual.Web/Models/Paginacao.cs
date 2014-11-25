using System;

namespace Quiron.LojaVirtual.Web.Models
{
    public class Paginacao
    {
        public int ItemTotal { get; set; }
        public int ItensPorPagina { get; set; }
        public int PaginaAtual { get; set; }

        public int TotalPagina
        {
            get { return (int)Math.Ceiling((decimal)ItemTotal / ItensPorPagina); }
        }
    }
}