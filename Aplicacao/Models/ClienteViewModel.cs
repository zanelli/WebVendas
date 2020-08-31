using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebVendas.Models
{
    public class ClienteViewModel
    {
        public int? Codigo { get; set; }
        [Required(ErrorMessage = "Informe o nome do cliente!")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Informe o CNPJ/CPF do cliente!")]
        public string CNPJ_CPF { get; set; }
        [Required(ErrorMessage = "Informe o e-mail do cliente!")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Informe o celular do cliente!")]
        public string Celular { get; set; }


    }
}
