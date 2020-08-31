using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebVendas.Models;

namespace Aplicacao.Servico.Interfaces
{
    public interface IServicoAplicacaoCliente 
    {
        IEnumerable<SelectListItem> ListaClientesDropDownList();
        IEnumerable<ClienteViewModel> Listagem();

        ClienteViewModel CarregarRegistro(int codigoCliente);

        void Cadastrar(ClienteViewModel cliente);

        void Excluir(int id);
    }
}
