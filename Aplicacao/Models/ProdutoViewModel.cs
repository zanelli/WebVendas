﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime;
using System.Threading.Tasks;

namespace WebVendas.Models
{
    public class ProdutoViewModel
    {
        public int? Codigo { get; set; }
        [Required(ErrorMessage = "Informe a descrição do produto!")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Informe quantidade do produto!")]
        public double Quantidade { get; set; }
        [Required(ErrorMessage = "Informe o valor unitário do produto!")]
        [Range(0.1, Double.PositiveInfinity)]
        public decimal? Valor { get; set; }
        [Required(ErrorMessage = "Informe a categoria do produto!")]
        public int? CodigoCategoria { get; set; }
        [DisplayName("Categoria")]
        public IEnumerable<SelectListItem> ListaCategorias { get; set; }
        public string DescricaoCategoria { get; set; }

    }
}
