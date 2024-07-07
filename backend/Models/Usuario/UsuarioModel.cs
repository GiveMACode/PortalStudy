using backend.Models.Pessoa;

namespace backend;

public class UsuarioModel
{
    public Guid Id { get; set; }
    public string? Usuario { get; set; }
    public string? Senha { get; set; }
    public Regra Regra { get; set; }
    public string? Email { get; set; }
    public PessoaModel Pessoa { get; set; }
}

public enum Regra
{
    Aluno,
    Professor,
    Coordenador,
    Diretor
}