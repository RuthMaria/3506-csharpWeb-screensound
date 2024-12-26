using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Banco;

/*
 Uma classe abstrata é uma classe que serve como modelo ou base para 
 outras classes, mas não pode ser instanciada diretamente. 
 Em vez disso, ela é projetada para ser estendida por outras classes 
 que implementarão (ou sobrescreverão) seus métodos.

Ela pode ter atributos, métodos concretos (com implementação), métodos 
abstratos (sem implementação) e construtores.

A diferença dela para uma interface é que ela possui a relação de 
"é um" (herança). Serve para compartilhar códigos semelhantes, já que a 
interface só possui assinaturas de métodos.

A interface é usada quando queremos apenas um contrato que será usado em
várias classes não relacionadas entre sim, mas possuem um determinado
comportamento semelhante. Interface não possui métodos concretos.

 */

/*
 A parte 'where T : class' define uma restrição genérica. 
 Isso significa que o tipo T passado para a classe DAL<T> deve ser uma 
 classe (não pode ser um tipo primitivo como int, bool, etc.).
 Essa restrição é importante porque o código trabalha com entidades do 
 Entity Framework, que são classes.
 */
internal abstract class DAL<T> where T : class
{
    protected readonly ScreenSoundContext context;

    protected DAL(ScreenSoundContext context)
    {
        this.context = context;
    }

    /*
       o Set identifica qual tipo estamos utilizando (artista ou música, por exemplo).
       Em seguida, é feito o acesso ao conjunto de entidades do tipo T.
    */
    public IEnumerable<T> Listar()
    {
       return context.Set<T>().ToList(); 
    }

    public void Adicionar(T objeto)
    {
        context.Set<T>().Add(objeto);
        context.SaveChanges(); // salva as alterações feita no banco
    }

    public void Atualizar(T objeto)
    {
        context.Set<T>().Update(objeto);
        context.SaveChanges();
    }

    public void Deletar(T objeto)
    {
        context.Set<T>().Remove(objeto);
        context.SaveChanges();
    }
}
