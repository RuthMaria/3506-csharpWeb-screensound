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
    public ArtistaDAL(ScreenSoundContext context): base(context){ }

    public Artista? RecuperarPeloNome(string nome)
    {
       return context.Artistas.FirstOrDefault(a => a.Nome.Equals(nome));
    }
}
