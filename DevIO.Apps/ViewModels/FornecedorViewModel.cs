using DevIO.Business.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DevIO.App.ViewModels
{
    public class FornecedorViewModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "This field is required")] //falta colocar o tamanho da string pra não ficar 100000000000000000
        public string Documento { get; set; }
        [DisplayName("Tipo")]
        public int TipoFornecedor { get; set; }
        public EnderecoViewModel Endereco { get; set; }
        [DisplayName("Ativo")]
        public bool Ativo { get; set; }

        /* EF Relations */
        public IEnumerable<ProdutoViewModel> Produtos { get; set; }
    }
}
