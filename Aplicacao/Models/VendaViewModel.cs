using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebVendas.Models
{
    public class VendaViewModel
    {
        public int? Codigo { get; set; }
        [Required(ErrorMessage = "Informe data da venda!")]
        public DateTime? Data { get; set; }
        [Required(ErrorMessage = "Informe o cliente!")]
        [DisplayName("Cliente")]
        public int? CodigoCliente { get; set; }
        public IEnumerable<SelectListItem> ListaClientes { get; set; }
        [DisplayName("Produto")]
        public IEnumerable<SelectListItem> ListaProdutos { get; set; }
        public string JsonProdutos { get; set; }
        public decimal Total { get; set; }

    }
}
