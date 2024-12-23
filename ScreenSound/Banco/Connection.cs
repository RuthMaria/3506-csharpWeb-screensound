using Microsoft.Data.SqlClient;
using ScreenSound.Modelos;

namespace ScreenSound.Banco;

internal class Connection
{
    private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ScreenSound;Integrated Security=True;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

    public SqlConnection ObterConexao()
    {
        return new SqlConnection(connectionString);
    }

    // Quando declaramos uma variável local como using, ela é descartada no
    // final do escopo em que ela foi declarada. Com isso conseguimos aplicar
    // uma boa prática e gerenciar melhor os recursos que estão sendo
    // utilizados e mantê-los somente quando estiverem sendo utilizados
    public IEnumerable<Artista> Listar()
    {
        var lista = new List<Artista>();
        using var connection = ObterConexao();
        connection.Open();

        string sql = "SELECT * FROM Artistas";
        SqlCommand command = new SqlCommand(sql, connection); //  representa a instrução que será executada
        using SqlDataReader dataReader = command.ExecuteReader(); // responsável por ler as informações do banco

        while (dataReader.Read())
        {
            string nomeArtista = Convert.ToString(dataReader["Nome"]);
            string bioArtista = Convert.ToString(dataReader["Bio"]);
            int idArtista = Convert.ToInt32(dataReader["Id"]);

            Artista artista = new(nomeArtista, bioArtista) { Id = idArtista };

            lista.Add(artista);
        }

        return lista;
    }

}
