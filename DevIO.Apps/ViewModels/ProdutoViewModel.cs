using DevIO.Business.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DevIO.App.ViewModels
{
    public class ProdutoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public Guid FornecedorId { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string Nome { get; set; }

        [DisplayName("Descrição")]
        [Required(ErrorMessage = "This field is required")]
        public string Descricao { get; set; }


        public IFormFile ImagemUpload { get; set; }

        public string Imagem { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public decimal Valor { get; set; }
        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }
        [DisplayName("Ativo")]
        public bool Ativo { get; set; }

        /* EF Relations */
        public FornecedorViewModel Fornecedor { get; set; }
        public IEnumerable<FornecedorViewModel> Fornecedores { get; set; } // it will store a list of fornecedores to populate the dropdown
    }
}
