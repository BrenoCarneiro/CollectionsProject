using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsProject.Models;

public class Usuario
{
    public string Nome { get; set; }
    public int Id { get; set; }
    public string Grupo { get; set; }

    public override string ToString()
    {
        string mensagem;
        if(String.IsNullOrEmpty(Grupo))
            mensagem =  "ID: " + Id + ", Nome: " + Nome;
        else
            mensagem = "ID: " + Id + ", Nome: " + Nome + ", Grupo: " + Grupo;

        return mensagem;
    }
}

public class Pessoa
{
    public string Nome { get; set; }
}
