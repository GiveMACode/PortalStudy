using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using backend.Models.Endereco;
using backend.Service.Exceptions;

namespace backend.Service.Endereco;
public class ViaCepService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<ViaCepService> _logger;

//logger de VIACEP
    public ViaCepService(HttpClient httpClient, ILogger<ViaCepService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

//Obter o Endereco por CEP
    public async Task<EnderecoModel> ObterEnderecoPorCepAsync(string cep)
    {
        //insere o cep no link
        var response = await _httpClient.GetAsync($"https://viacep.com.br/ws/{cep}/json/");
        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            _logger.LogInformation("JSON recebido: {Json}", json);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var endereco = JsonSerializer.Deserialize<EnderecoModel>(json, options);
            if (endereco != null && endereco.Cep != null)
            { //retorna o endereco
                return endereco;
            }
        }//informa o erro 
        _logger.LogError("Falha ao obter endereço. StatusCode: {StatusCode}", response.StatusCode);
        throw new CepNotFoundException(cep);
    }
}