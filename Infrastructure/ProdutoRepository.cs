using System.Linq;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public class ProdutoRepository
    {

        private List<ProdutoModel> produtos = new List<ProdutoModel>();


        public List<ProdutoModel> Pesquisar(string termoDePesquisa)
        {
            return produtos.Where(x => x._NomeProduto.ToLower().Contains(termoDePesquisa.ToLower())).ToList();

        }

        public void Adicionar(ProdutoModel _adicionarProduto)
        {
            produtos.Add(_adicionarProduto);
        }

        public DateTime Garantia(DateTime garantia)
        {
            DateTime dtgarantia = new DateTime();
            dtgarantia = garantia;
            dtgarantia.AddYears(1);

            return dtgarantia;
        }
    }
}
