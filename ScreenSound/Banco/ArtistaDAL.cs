using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ScreenSound.Modelos;

/*
 
Diferença entre DAL (Data Access Object) e DAO (Data Access Layer)
 O DAL é a camada de acesso a dados que promove a abstração desses dados e vai 
emitir todos os comandos de SELECT, INSERT, UPDATE E DELETE de maneira 
separada da lógica das classes do projeto e independente da fonte de dados, 
enquanto o DAO é um objeto do banco de dados que representa um banco aberto.

Basicamente, o DAL representa a estrutura de acesso aos dados, independente do
tipo de banco utilizado, e o DAO é o objeto que representa o acesso a uma 
fonte de dados específica
 */
namespace ScreenSound.Banco;

internal abstract class ArtistaDAL: DAL<Artista>
{
    private readonly ScreenSoundContext context;

    public ArtistaDAL(ScreenSoundContext context)
    {
        this.context = context;
    }

    // Quando declaramos uma variável local como using, ela é descartada no
    // final do escopo em que ela foi declarada. Com isso conseguimos aplicar
    // uma boa prática e gerenciar melhor os recursos que estão sendo
    // utilizados e mantê-los somente quando estiverem sendo utilizados
    public override IEnumerable<Artista> Listar()
    {
        return context.Artistas.ToList();
    }

    //public IEnumerable<Artista> ListarUsandoAdoNet()
    //{
    //    var lista = new List<Artista>();
    //    using var connection = new ScreenSoundContext().ObterConexaoUsandoAdoNet();
    //    connection.Open();

    //    string sql = "SELECT * FROM Artistas";
    //    SqlCommand command = new SqlCommand(sql, connection); //  representa a instrução que será executada no banco de dados
    //    using SqlDataReader dataReader = command.ExecuteReader(); // responsável por ler as informações do banco

    //    while (dataReader.Read())
    //    {
    //        string nomeArtista = Convert.ToString(dataReader["Nome"]);
    //        string bioArtista = Convert.ToString(dataReader["Bio"]);
    //        int idArtista = Convert.ToInt32(dataReader["Id"]);

    //        Artista artista = new(nomeArtista, bioArtista) { Id = idArtista };

    //        lista.Add(artista);
    //    }

    //    return lista;
    //}

    public override void Adicionar(Artista artista)
    {
        context.Artistas.Add(artista);
        context.SaveChanges(); // salva as alterações feita no banco
    }

    //public void AdicionarUsandoAdoNet(Artista artista)
    //{
    //    using var connection = new ScreenSoundContext().ObterConexaoUsandoAdoNet();
    //    connection.Open();

    //    string sql = "INSERT INTO Artistas (Nome, FotoPerfil, Bio) VALUES (@nome, @perfilPadrao, @bio)";
    //    SqlCommand command = new SqlCommand(sql, connection);

    //    command.Parameters.AddWithValue("@nome", artista.Nome);
    //    command.Parameters.AddWithValue("@perfilPadrao", artista.FotoPerfil);
    //    command.Parameters.AddWithValue("@bio", artista.Bio);

    //    int retorno = command.ExecuteNonQuery();
    //    Console.WriteLine($"Linhas afetadas: {retorno}");
    //}

    public override void Atualizar(Artista artista)
    {
        context.Artistas.Update(artista);
        context.SaveChanges();

    }

    //public void AtualizarUsandoAdoNet(Artista artista)
    //{
    //    using var connection = new ScreenSoundContext().ObterConexaoUsandoAdoNet();
    //    connection.Open();

    //    string sql = "UPDATE Artistas SET Nome = @nome, Bio = @bio WHERE Id = @id";
    //    SqlCommand command = new SqlCommand(sql, connection);

    //    command.Parameters.AddWithValue("@nome", artista.Nome);
    //    command.Parameters.AddWithValue("@bio", artista.Bio);
    //    command.Parameters.AddWithValue("@id", artista.Id);

    //    int retorno = command.ExecuteNonQuery();
    //    Console.WriteLine($"Linhas afetadas: {retorno}");
    //}

    public override void Deletar(Artista artista)
    {
        context.Artistas.Remove(artista);
        context.SaveChanges();
    }

    //public void DeletarUsandoAdoNet(Artista artista)
    //{
    //    using var connection = new ScreenSoundContext().ObterConexaoUsandoAdoNet();
    //    connection.Open();

    //    string sql = "DELETE FROM Artistas WHERE Id = @id";
    //    SqlCommand command = new SqlCommand(sql, connection);

    //    command.Parameters.AddWithValue("@id", artista.Id);

    //    int retorno = command.ExecuteNonQuery();
    //    Console.WriteLine($"Linhas afetadas: {retorno}");
    //}

    public Artista? RecuperarPeloNome(string nome)
    {
       return context.Artistas.FirstOrDefault(a => a.Nome.Equals(nome));
    }
}
