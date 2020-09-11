﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebVendas.Models;

namespace Aplicacao.Servico.Interfaces
{
    public interface IServicoAplicacaoVenda 
    {
        IEnumerable<VendaViewModel> Listagem();

        VendaViewModel CarregarRegistro(int codigoVenda);

        void Cadastrar(VendaViewModel venda);

        void Excluir(int id);

        IEnumerable<GraficoViewModel> ListaGrafico();
    }
}
