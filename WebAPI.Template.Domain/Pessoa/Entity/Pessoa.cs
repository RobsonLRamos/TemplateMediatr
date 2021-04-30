using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Template.Domain.Pessoa.Entity
{
    public class Pessoa
    {
        public Pessoa(int id, string nome, string telefone, int idade, string cPF)
        {
            Id = id;
            Nome = nome;
            Telefone = telefone;
            Idade = idade;
            CPF = cPF;
        }

        public int Id { get; set; }

        public string Nome { get; set; }

        public string Telefone { get; set; }

        public int Idade { get; set; }

        public string CPF { get; set; }


    }
}
