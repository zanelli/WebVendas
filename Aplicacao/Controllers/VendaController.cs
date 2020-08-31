using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacao.Servico;
using Aplicacao.Servico.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebVendas.Models;

namespace WebVendas.Controllers
{
    public class VendaController : Controller
    {
        readonly IServicoAplicacaoProduto ServicoAplicacaoProduto;
        readonly IServicoAplicacaoCliente ServicoAplicacaoCliente;
        readonly IServicoAplicacaoVenda ServicoAplicacaoVenda;

        public VendaController(
            IServicoAplicacaoProduto servicoAplicacaoProduto,
            IServicoAplicacaoCliente servicoAplicacaoCliente,
            IServicoAplicacaoVenda servicoAplicacaoVenda)
        {
            ServicoAplicacaoProduto = servicoAplicacaoProduto;
            ServicoAplicacaoCliente = servicoAplicacaoCliente;
            ServicoAplicacaoVenda = servicoAplicacaoVenda;
        }
        public IActionResult Index()
        {
            ViewData["Title"] = "Vendas";
            return View(ServicoAplicacaoVenda.Listagem());
        }

        [HttpGet]
        public IActionResult Cadastro(int? id)
        {
            ViewData["Title"] = "Vendas";
            VendaViewModel vm = new VendaViewModel();
            if(id!=null)
            {
                vm = ServicoAplicacaoVenda.CarregarRegistro((int)id);
            }
            vm.ListaClientes = ServicoAplicacaoCliente.ListaClientesDropDownList();
            vm.ListaProdutos = ServicoAplicacaoProduto.ListaProdutosDropDownList();
            return View(vm);
        }

        [HttpPost]
        public IActionResult Cadastro(VendaViewModel entidade)
        {
            if (ModelState.IsValid)
            {
                ServicoAplicacaoVenda.Cadastrar(entidade);
            }
            else
            {
                entidade.ListaClientes = ServicoAplicacaoCliente.ListaClientesDropDownList();
                entidade.ListaProdutos = ServicoAplicacaoProduto.ListaProdutosDropDownList();
                return View(entidade);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Excluir(int id)
        {
            ServicoAplicacaoVenda.Excluir(id);
            return RedirectToAction("Index");
        }

        [HttpGet("LerValorProduto/{CodigoProduto}")]
        public decimal LerValorProduto(int CodigoProduto)
        {
            return (decimal)ServicoAplicacaoProduto.CarregarRegistro(CodigoProduto).Valor;
        }
    }
}
