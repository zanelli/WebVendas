﻿using System;
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
    public class ProdutoController : Controller
    {
        readonly IServicoAplicacaoProduto ServicoAplicacaoProduto;
        readonly IServicoAplicacaoCategoria ServicoAplicacaoCategoria;

        public ProdutoController(
            IServicoAplicacaoProduto servicoAplicacaoProduto,
            IServicoAplicacaoCategoria servicoAplicacaoCategoria)
        {
            ServicoAplicacaoProduto = servicoAplicacaoProduto;
            ServicoAplicacaoCategoria = servicoAplicacaoCategoria;
        }
        public IActionResult Index()
        {
            ViewData["Title"] = "Produtos";
            return View(ServicoAplicacaoProduto.Listagem());
        }

        [HttpGet]
        public IActionResult Cadastro(int? id)
        {
            ViewData["Title"] = "Cadastro de Produtos";
            ProdutoViewModel viewModel = new ProdutoViewModel();
            if (id != null)
            {
                viewModel = ServicoAplicacaoProduto.CarregarRegistro((int)id);
            }
            viewModel.ListaCategorias = ServicoAplicacaoCategoria.ListaCategoriasDropDownList();

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Cadastro(ProdutoViewModel entidade)
        {
            if (ModelState.IsValid)
            {
                ServicoAplicacaoProduto.Cadastrar(entidade);
            }
            else
            {
                entidade.ListaCategorias = ServicoAplicacaoCategoria.ListaCategoriasDropDownList();
                return View(entidade);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Excluir(int id)
        {
            ServicoAplicacaoProduto.Excluir(id);
            return RedirectToAction("Index");
        }
    }
}
