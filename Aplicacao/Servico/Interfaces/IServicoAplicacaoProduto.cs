using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebVendas.Models;

namespace Aplicacao.Servico.Interfaces
{
    public interface IServicoAplicacaoProduto
    {
        IEnumerable<SelectListItem> ListaProdutosDropDownList();
        IEnumerable<ProdutoViewModel> Listagem();

        ProdutoViewModel CarregarRegistro(int codigoProduto);

        void Cadastrar(ProdutoViewModel produto);

        void Excluir(int id);
    }
}
