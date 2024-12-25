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

internal abstract class DAL<T>
{
    public abstract IEnumerable<T> Listar();
    public abstract void Adicionar(T objeto);
    public abstract void Atualizar(T objeto);
    public abstract void Deletar(T objeto);
}
