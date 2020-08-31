using System;
using System.Collections.Generic;
using System.Text;
using WebVendas.Dominio.Entidades;

namespace Dominio.Repositorio
{
    public interface IRepositorioVenda :IRepositorio<Venda>
    {
        new void Delete(int id);
    }
}
