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
    public class ServicoAplicacaoProduto : IServicoAplicacaoProduto
    {
        private IServicoProduto ServicoProduto;
        public ServicoAplicacaoProduto(IServicoProduto servicoProduto)
        {
            ServicoProduto = servicoProduto;

        }

        public void Cadastrar(ProdutoViewModel produto)
        {
            Produto item = new Produto()
            {
                Codigo = produto.Codigo,
                Descricao  = produto.Descricao,
                Quantidade = produto.Quantidade,
                Valor =(decimal) produto.Valor,
                CodigoCategoria = (int)produto.CodigoCategoria
            };
            ServicoProduto.Cadastrar(item);
        }

        public ProdutoViewModel CarregarRegistro(int codigoProduto)
        {
            var registro = ServicoProduto.CarregarRegistro(codigoProduto);
            ProdutoViewModel produto = new ProdutoViewModel()
            {
                Codigo = registro.Codigo,
                Descricao = registro.Descricao,
                Quantidade = registro.Quantidade,
                Valor = (decimal)registro.Valor,
                CodigoCategoria = (int)registro.CodigoCategoria
            };

            return produto;
        }

        public void Excluir(int id)
        {
            ServicoProduto.Excluir(id);
        }

        public IEnumerable<ProdutoViewModel> Listagem()
        {
            var lista = ServicoProduto.Listagem();
            List<ProdutoViewModel> listaProduto = new List<ProdutoViewModel>();
            foreach (var item in lista)
            {
                ProdutoViewModel produto = new ProdutoViewModel()
                {
                    Codigo = item.Codigo,
                    Descricao = item.Descricao,
                    Quantidade = item.Quantidade,
                    Valor = (decimal)item.Valor,
                    CodigoCategoria = (int)item.CodigoCategoria,
                    DescricaoCategoria = item.Categoria.Descricao
                };
                listaProduto.Add(produto);
            }
            return listaProduto;
        }

        public IEnumerable<SelectListItem> ListaProdutosDropDownList()
        {
            List<SelectListItem> retorno = new List<SelectListItem>();
            var lista = this.Listagem();
            foreach (var item in lista)
            {
                SelectListItem produto = new SelectListItem()
                {
                    Value = item.Codigo.ToString(),
                    Text = item.Descricao
                };
                retorno.Add(produto);
            }
            return retorno;
        }
    }
}
