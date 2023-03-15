using CollectionsProject.Models;

var usuarios = new List<Usuario>() {
    new Usuario() { Id = 5, Grupo = "Diretoria", Nome = "Carlos" },
    new Usuario() { Id = 21, Grupo = "Diretoria", Nome = "José" },
    new Usuario() { Id = 3, Grupo = "RH", Nome = "Camila" },
    new Usuario() { Id = 42, Grupo = "RH", Nome = "Joana" },
    new Usuario() { Id = 102, Grupo = "", Nome = "Joaquim" },
    new Usuario() { Id = 7, Grupo = "RH", Nome = "Camila" },
    new Usuario() { Id = 105, Grupo = "Operações", Nome = "Vitor" }
};

var novosUsuarios = new List<Usuario>
{
    new Usuario() { Id = 6, Grupo = "Coordenação", Nome = "Maria" },
    new Usuario() { Id = 22, Grupo = "Administrativo", Nome = "Ana" },
    new Usuario() { Id = 4, Grupo = "RH", Nome = "Carla" },
    new Usuario() { Id = 41, Grupo = "Administrativo", Nome = "Mário" },
    new Usuario() { Id = 101, Grupo = "", Nome = "Manoel" },
    new Usuario() { Id = 8, Grupo = "Administrativo", Nome = "Samuel" },
    new Usuario() { Id = 104, Grupo = "Operações", Nome = "Marcelo" }
};

//1 - Concatenando uma nova lista à lista inicial utilizando o método AddRange
usuarios.AddRange(novosUsuarios);


//2 - Encontrar todos usuários que pertencem ao grupo Diretoria
//2.1 - FindAll é um método da classe List que pertence ao namespace System.Collections.Generic
//Esse método retorna uma nova lista que é preenchida com os valores encontrados que foram passados como parâmetro 
Console.WriteLine($"Usuários que pertencem ao grupo \"Diretoria\": ");
foreach (Usuario usuario in usuarios.FindAll(x => x.Grupo.Contains("Diretoria")))
    Console.WriteLine(usuario + " -> Encontrado utilizando o método FindAll");

//2.2 - Where (utilizado abaixo) é um método da classe Enumerable que pertence ao namespace System.Linq
//Esse método tem uma performace melhor comparado ao FindAll
//O Where testa cada elemento de origem, retornando um objeto (ao invés de uma lista) que armazena a enumeração dos elementos encontrados
foreach (Usuario usuario in usuarios.Where(x => x.Grupo.Contains("Diretoria")))
    Console.WriteLine(usuario + " -> Encontrado utilizando o método Where");


//3 - Encontrar um usuário que não possui grupo, verificando se existe um que satisfaça essa condição
Console.WriteLine($"\nUsuário sem grupo: ");
var usuarioSemGrupo = usuarios.FirstOrDefault(x => x.Grupo == "");
Console.WriteLine(usuarioSemGrupo == null ? $"Não há usuários sem grupo" : $"{usuarioSemGrupo}");



//4 - Encontrar um usuário cujo nome seja "Camila" utilizando o método FirstOrDefault
Console.WriteLine($"\nUsuário encontrado com o nome \"Camila\": ");
Console.WriteLine(usuarios.Find(x => x.Nome.Equals("Camila")));


//5 - Obter uma lista dos ids dos usuários em ordem crescente, utilizando o método OrderBy
Console.WriteLine($"\nUsuários organizados por Id (crescente): ");
foreach (Usuario usuario in usuarios.OrderBy(x => x.Id))
    Console.WriteLine(usuario);


//6 - Obter uma lista dos ids dos usuários em ordem decrescente, utilizando o método OrderByDescending
Console.WriteLine($"\nUsuários organizados por Id (decrescente): ");
foreach (Usuario usuario in usuarios.OrderByDescending(x => x.Id))
    Console.WriteLine(usuario);


//7 - Agrupar usuários por grupo, utilizando o método GroupBy
Console.Write($"\nUsuários organizados por grupo: ");
foreach (var grupo in usuarios.GroupBy(x => x.Grupo))
{
    if(grupo.Key != "")
        Console.Write($"\n{grupo.Key} - ");
    else
        Console.Write($"\nSem Grupo - ");
    foreach (var usuario in grupo)
        Console.Write(usuario.Nome + " ");
}

//8 - Obter uma lista de Pessoas a partir da lista fornecida
//8.1 O Select é um método da classe Enumerable que pertence ao namespace System.Linq
//Esse método consulta uma coleção, seleciona e retorna as informações desejadas
Console.WriteLine($"\n\nLista com os nomes dos usuários: ");
foreach (string pessoa in usuarios.Select(x => x.Nome))
    Console.WriteLine(pessoa + " -> Utilizando o método Select");

//8.2 - O ConvertAll é um método da classe List que percente ao namespace System.Collections.Generic
//Cada elemento é convertido individualmente e em seguida passados para uma nova lista, só pode ser utilizado em coleções do tipo lista
Console.WriteLine($"\nLista com os nomes dos usuários: ");
foreach (string pessoa in usuarios.ConvertAll(x => x.Nome))
    Console.WriteLine(pessoa + " -> Utilizando o método ConvertAll");