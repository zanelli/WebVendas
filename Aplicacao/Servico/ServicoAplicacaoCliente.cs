using Aplicacao.Servico.Interfaces;
using Dominio.Entidades.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebVendas.Dominio.Entidades;
using WebVendas.Models;

namespace Aplicacao.Servico
{
    public class ServicoAplicacaoCliente : IServicoAplicacaoCliente
    {
        private IServicoCliente ServicoCliente;
        public ServicoAplicacaoCliente(IServicoCliente servicoCliente)
        {
            ServicoCliente = servicoCliente;

        }

        public void Cadastrar(ClienteViewModel Cliente)
        {
            Cliente item = new Cliente()
            {
                Codigo = Cliente.Codigo,
                Nome  = Cliente.Nome,
                CNPJ_CPF = Cliente.CNPJ_CPF,
                Celular = Cliente.Celular,
                Email = Cliente.Email
            };
            ServicoCliente.Cadastrar(item);
        }

        public ClienteViewModel CarregarRegistro(int codigoCliente)
        {
            var registro = ServicoCliente.CarregarRegistro(codigoCliente);
            ClienteViewModel Cliente = new ClienteViewModel()
            {
                Codigo = registro.Codigo,
                Nome = registro.Nome,
                CNPJ_CPF = registro.CNPJ_CPF,
                Celular = registro.Celular,
                Email = registro.Email
            };

            return Cliente;
        }

        public void Excluir(int id)
        {
            ServicoCliente.Excluir(id);
        }

        public IEnumerable<ClienteViewModel> Listagem()
        {
            var lista = ServicoCliente.Listagem();
            List<ClienteViewModel> listaCliente = new List<ClienteViewModel>();
            foreach (var item in lista)
            {
                ClienteViewModel Cliente = new ClienteViewModel()
                {
                    Codigo = item.Codigo,
                    Nome = item.Nome,
                    CNPJ_CPF = item.CNPJ_CPF,
                    Celular = item.Celular,
                    Email = item.Email
                };
                listaCliente.Add(Cliente);
            }
            return listaCliente;
        }

        public IEnumerable<SelectListItem> ListaClientesDropDownList()
        {
            List<SelectListItem> retorno = new List<SelectListItem>();
            var lista = this.Listagem();
            foreach (var item in lista)
            {
                SelectListItem cliente = new SelectListItem()
                {
                    Value = item.Codigo.ToString(),
                    Text = item.Nome
                };
                retorno.Add(cliente);
            }
            return retorno;
        }
    }
}
