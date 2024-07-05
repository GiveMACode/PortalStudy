using System.ComponentModel.DataAnnotations;
using backend.Models.Endereco;
using backend.Models.Telefone;

namespace backend.Models.Pessoa;

    public class PessoaModel
    {

        public Guid Id { get; set; }

        [Required]
        [StringLength(100)]
        public string? Nome { get; set; }

        [Required]
        [StringLength(11)]
        public string? CPF { get; set; }

        [Required]
        public DateTime DataNascimento { get; set; }

        public EnderecoModel? Endereco { get; set; }

        public ICollection<TelefoneModel>? Telefones { get; set; }

        public  MyProperty { get; set; }

        
}
