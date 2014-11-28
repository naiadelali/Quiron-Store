using System.Collections.Generic;
using System.Linq;

namespace Quiron.LojaVirtual.Dominio.Entidades
{
    public class Carrinho
    {
        private readonly List<ItemCarrinho> _itemCarrinhos =  new List<ItemCarrinho>(); 

        //Adicionar
        public void Adicionar(Produto produto, int quantidade)
        {
            ItemCarrinho item = _itemCarrinhos.FirstOrDefault(p => p.Produto.ProdutoId == produto.ProdutoId);

            if (item == null)
            {
                _itemCarrinhos.Add(new ItemCarrinho{
                    Produto = produto,
                    Quantidade = quantidade
                    });
            }
            else
            {
                item.Quantidade += quantidade;
            }
        }

        //Remover
        public void Remover(Produto produto)
        {
            _itemCarrinhos.RemoveAll(p => p.Produto.ProdutoId == produto.ProdutoId);
        }

        //Limpar carrinho
        public void LimparCarrinho()
        {
            _itemCarrinhos.Clear();
        }

        //Obter valor total
        public decimal ObterValorTotal()
        {
            return _itemCarrinhos.Sum(e => e.Produto.Preco*e.Quantidade);
        }

        //Listar produtos do carrinho
        public IEnumerable<ItemCarrinho> ListarItemCarrinhos()
        {
            return _itemCarrinhos;
        }
    }

    public class ItemCarrinho
    {
        public Produto Produto { get; set; }

        public int Quantidade { get; set; }
    }
}
