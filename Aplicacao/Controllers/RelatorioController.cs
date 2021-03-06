﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Aplicacao.Servico.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebVendas.Models;

namespace WebVendas.Controllers
{
    public class RelatorioController : Controller
    {
        readonly IServicoAplicacaoVenda ServicoVenda;

        public RelatorioController(IServicoAplicacaoVenda servicoVenda)
        {
            ServicoVenda = servicoVenda;
        }
        public IActionResult Grafico()
        {
            ViewData["Title"] = "Gráfico";


            var lista = ServicoVenda.ListaGrafico().ToList();

            // A consulta acima é equivalente a essa query:
            //select sum(v.Quantidade) as qtdvendida, p.Codigo, p.Descricao
            //from
            //    VendaProdutos v,
            //    produto p
            //where v.CodigoProduto = p.Codigo
            //group by p.Codigo, p.Descricao


            string valores = string.Empty;
            string labels = string.Empty;
            string cores = string.Empty;
            var random = new Random();
            for (int i = 0; i < lista.Count(); i++)
            {
                valores += lista[i].TotalVendido.ToString() + ",";
                labels += "'" + lista[i].Descricao.ToString() + "',";
                cores += "'" + String.Format("#{0:X6}", random.Next(0x1000000)) + ",";

            }

            ViewBag.Valores = valores;
            ViewBag.Labels = labels;
            ViewBag.Cores = cores;
            return View();
        }
    }
}
