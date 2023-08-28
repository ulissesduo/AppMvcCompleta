using DevIO.Business.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevIO.App.ViewModels
{
    public class FornecedorViewModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "This field is required")] //i must add a size on this inputs
        public string Documento { get; set; }
        [DisplayName("Tipo")]
        public int TipoFornecedor { get; set; }
        public EnderecoViewModel Endereco { get; set; }
        [DisplayName("Ativo")]
        public bool Ativo { get; set; }
        [NotMapped]
        public IEnumerable<ProdutoViewModel> Produtos { get; set; }
    }
}
