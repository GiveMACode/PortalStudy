using System.ComponentModel.DataAnnotations;
using backend.Models.Pessoa;
namespace backend.Models.Telefone;

public class TelefoneModel
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "O tipo de telefone é obrigatório.")]
    public TipoTelefone Tipo { get; set; } // Celular, Residencial, Comercial

    [Required(ErrorMessage = "O número de telefone é obrigatório.")]
   // [PhoneValidation(ErrorMessage = "O formato do número de telefone é inválido.")]
    public string? Numero { get; set; }

    // Chave estrangeira para a classe Pessoa
    public Guid PessoaId { get; set; }
    public PessoaModel? Pessoa { get; set; }
}

public enum TipoTelefone
{
    Residencial,
    Comercial,
    Celular
}