using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ScreenSound.Modelos;

namespace ScreenSound.Banco;

/*
 DbContext representa a sessão com o banco de dados. 
 Cada Objeto DbSet<Artista> representa um tipo de entidade no banco de 
 dados, ou seja, uma tabela.
 
 */
internal class ScreenSoundContext: DbContext
{
    public DbSet<Artista> Artistas { get; set; }
    public DbSet<Musica> Musicas { get; set; }


    private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ScreenSoundV0;Integrated Security=True;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(connectionString);
    }

    /*
     public SqlConnection ObterConexaoUsandoAdoNet()
     {
        return new SqlConnection(connectionString);
     }
    */
}
