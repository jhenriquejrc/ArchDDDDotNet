using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ArquiteturaDDD.MVC.ViewModels
{
    public class ClientViewModel
    {
        [Key]
        public int ClientId { get; set; }
        [Required(ErrorMessage = "Preencha o campo nome.")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres.")]
        [MinLength(2, ErrorMessage = "Minimo {0} caracteres.")]
        [DisplayName("Nome")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Preencha o campo sobrenome.")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres.")]
        [MinLength(2, ErrorMessage = "Minimo {0} caracteres.")]
        [DisplayName("Sobrenome")]
        public string Lastname { get; set; }
        [Required(ErrorMessage = "Preencha o campo email.")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres.")]
        [EmailAddress(ErrorMessage = "Preencha um email válido.")]
        [DisplayName("E-mail")]
        public string Email { get; set; }
        [ScaffoldColumn(false)]
        public DateTime Created { get; set; }
        [DisplayName("Ativo?")]
        public bool Active { get; set; }
        public virtual IEnumerable<ProductViewModel> Products { get; set; }

       
    }
}