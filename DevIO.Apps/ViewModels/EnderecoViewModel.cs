using DevIO.Business.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DevIO.App.ViewModels
{
    public class EnderecoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "This field is required")] //I must add stringLength limit
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "This field is required")] 
        public string Complemento { get; set; }

        [Required(ErrorMessage = "This field is required")] 
        public string Cep { get; set; }

        [Required(ErrorMessage = "This field is required")] 
        public string Bairro { get; set; }
        
        [Required(ErrorMessage = "This field is required")] 
        public string Cidade { get; set; }
        
        [Required(ErrorMessage = "This field is required")] 
        public string Estado { get; set; }

        /* EF Relation */
        [HiddenInput]
        public Fornecedor Fornecedor { get; set; }
    }
}
