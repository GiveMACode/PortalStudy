using backend.Models.Endereco;
using backend.Models.Telefone;

namespace backend.ViewModels;

public class PessoaViewModel
{
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public EnderecoModel? Endereco { get; set; }
        public ICollection<TelefoneModel>? Telefones { get; set; }
        public UsuarioModel Usuario { get; set; }
}
