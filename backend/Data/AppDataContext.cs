using Microsoft.EntityFrameworkCore;
using backend.Models;
using backend.Models.Pessoa;
using backend.Models.Endereco;
using backend.Models.Telefone;

namespace backend.Data;


public class AppDataContext : DbContext
{
    public AppDataContext(DbContextOptions<AppDataContext> options) : base(options){}

    //implementado projeto em vida longa, com adicao de banco de dados
    //utilizacao do EntityFramework para geracao de BD
    
    // Abaixo as Classes que vao virar tabelas no Banco de Dados
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Endereco
        modelBuilder.Entity<EnderecoModel>().HasKey(e => e.Id);

        modelBuilder.Entity<EnderecoModel>()
                    .HasOne(e => e.Pessoa)
                    .WithOne(p => p.Endereco)
                    .HasForeignKey<EnderecoModel>(e => e.Id)
                    .IsRequired(true);
        //Telefone
        modelBuilder.Entity<TelefoneModel>().HasKey(t => t.Id);

        modelBuilder.Entity<TelefoneModel>()
                    .HasOne(t => t.Pessoa)
                    .WithMany(p => p.Telefones)
                    .HasForeignKey(e => e.PessoaId)
                    .IsRequired(true);
        

        
        {
            
        }
        
        
        
        base.OnModelCreating(modelBuilder);
        //utilizando model builder para a definicao das classes e chaves primarias e estrangeiras
       
         // Configuração do relacionamento Pessoa <-> Telefone

        


    }


    }