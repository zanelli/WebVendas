using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebVendas.Models
{
    public class CategoriaViewModel
    {
        public int? Codigo { get; set; }
        [DisplayName("Descrição")]
        [Required(ErrorMessage ="Informe a descrição da categoria!")]
        public string Descricao { get; set; }
    }
}
