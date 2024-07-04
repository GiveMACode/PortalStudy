using backend.Service.Endereco;
using backend.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
namespace backend.Controllers;

[ApiController]
[Route("[controller]")]
public class EnderecoController : ControllerBase
{
    private readonly ViaCepService _viaCepService;

    public EnderecoController(ViaCepService viaCepService)
    {
        _viaCepService = viaCepService;
    }

    [HttpGet("{cep}")]
    public async Task<ActionResult<EnderecoViewModel>> GetEndereco(string cep)
    {
        var endereco = await _viaCepService.ObterEnderecoPorCepAsync(cep);

        if (endereco == null)
        {
            return NotFound();
        }

        var enderecoViewModel = new EnderecoViewModel
        {
            Cep = endereco.Cep,
            Logradouro = endereco.Logradouro,
            Complemento = endereco.Complemento,
            Bairro = endereco.Bairro,
            Localidade = endereco.Localidade,
            Uf = endereco.Uf,
            Ibge = endereco.Ibge,
            Gia = endereco.Gia,
            Ddd = endereco.Ddd,
            Siafi = endereco.Siafi
        };

        return Ok(enderecoViewModel);
    }
}