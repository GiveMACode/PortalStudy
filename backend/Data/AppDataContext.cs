using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Data;


public class AppDataContext : DbContext
{
    public AppDataContext(DbContextOptions<AppDataContext> options) : base(options){}

    //implementado projeto em vida longa, com adicao de banco de dados
    //utilizacao do EntityFramework para geracao de BD
    
    // Abaixo as Classes que vao virar tabelas no Banco de Dados
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        //utilizando model builder para a definicao das classes e chaves primarias e estrangeiras
       
         // Configuração do relacionamento Pessoa <-> Telefone
    }


    }