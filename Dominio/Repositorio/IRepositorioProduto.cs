using System;
using System.Collections.Generic;
using System.Text;
using WebVendas.Dominio.Entidades;

namespace Dominio.Repositorio
{
    public interface IRepositorioProduto :IRepositorio<Produto>
    {
        new IEnumerable<Produto> Read();
    }
}
