using Dominio.Repositorio;
using Microsoft.EntityFrameworkCore;
using Repositorio.Contexto;
using System.Collections.Generic;
using System.Linq;
using WebVendas.Dominio.DTO;
using WebVendas.Dominio.Entidades;

namespace Repositorio.Entidades
{
    public class RepositorioVendaProdutos : IRepositorioVendaProdutos
    {
        protected ApplicationDbContext DbSetContext;
        public RepositorioVendaProdutos(ApplicationDbContext mContext)
        {
            DbSetContext = mContext;
        }

        public IEnumerable<GraficoViewModel> ListaGrafico()
        {
            var lista = DbSetContext.VendaProdutos.Include(x => x.Produto)
                .GroupBy(x => x.CodigoProduto)
           .Select(y => new GraficoViewModel()
           {
               CodigoProduto = y.First().CodigoProduto,
               Descricao = y.First().Produto.Descricao,
               TotalVendido = y.Sum(z => z.Quantidade)
           }).ToList();

            return lista;

            //    // A consulta acima é equivalente a essa query:
            //    //select sum(v.Quantidade) as qtdvendida, p.Codigo, p.Descricao
            //    //from
            //    //    VendaProdutos v,
            //    //    produto p
            //    //where v.CodigoProduto = p.Codigo
            //    //group by p.Codigo, p.Descricao
        }
    }
}
