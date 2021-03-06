﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using WebVendas.Dominio.DTO;
using WebVendas.Dominio.Entidades;

namespace Dominio.Entidades.Interfaces
{
    public interface IServicoVenda : IServicoCrud<Venda>
    {
        IEnumerable<GraficoViewModel> ListaGrafico();
    }
}
