using Dominio.Repositorio;
using Microsoft.EntityFrameworkCore;
using Repositorio.Contexto;
using Repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebVendas.Dominio.Entidades;

namespace Repositorio.Entidades
{
    public class RepositorioVenda : Repositorio<Venda>, IRepositorioVenda
    {
        public RepositorioVenda(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public override void Delete(int id)
        {
            // Apaga registros da vendaprodutos primeiro
            var listaProdutos =
                DbSetContext.Include(x => x.Produtos)
                .Where(y => y.Codigo == id)
                .AsNoTracking().ToList();

            VendaProdutos vendaprodutos;
            foreach (var item in listaProdutos[0].Produtos)
            {
                vendaprodutos = new VendaProdutos();
                vendaprodutos.CodigoVenda = id;
                vendaprodutos.CodigoProduto = item.CodigoProduto;

                DbSet<VendaProdutos> DbSetAux;
                DbSetAux = Db.Set<VendaProdutos>();
                DbSetAux.Attach(vendaprodutos);
                DbSetAux.Remove(vendaprodutos);
                Db.SaveChanges();
            }

            
          
            base.Delete(id);
    }
}
}
