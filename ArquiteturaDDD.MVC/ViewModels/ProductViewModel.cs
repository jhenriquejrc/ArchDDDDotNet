using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArquiteturaDDD.MVC.ViewModels
{
    public class ProductViewModel
    {
        [Key]
        [DisplayName("Código")]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Preencha o campo de descrição.")]
        [MaxLength(250, ErrorMessage ="Máximo {0} caracteres.")]
        [MinLength(2, ErrorMessage ="Mínimo {0} caracteres.")]
        [DisplayName("Descrição")]
        public string Description { get; set; }
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Preencha um valor.")]
        [DisplayName("Valor")]
        public decimal Price { get; set; }
        [DisplayName("Disponível?")]
        public bool Available { get; set; }
        [ScaffoldColumn(false)]
        public int ClientId { get; set; }
        public virtual ClientViewModel Client { get; set; }
    }
}