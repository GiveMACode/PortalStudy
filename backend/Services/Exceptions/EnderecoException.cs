namespace backend.Service.Exceptions;

public class CepNotFoundException : Exception
{
    public CepNotFoundException(string cep)
        : base($"Endereço não encontrado para o CEP: {cep}")
    {
    }
}
