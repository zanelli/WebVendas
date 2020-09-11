using System;
using System.Collections.Generic;
using System.Text;
using WebVendas.Dominio.DTO;
using WebVendas.Dominio.Entidades;

namespace Dominio.Repositorio
{
    public interface IRepositorioVendaProdutos
    {
        IEnumerable<GraficoViewModel> ListaGrafico();
    }
}
