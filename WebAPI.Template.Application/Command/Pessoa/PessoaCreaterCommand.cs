using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Template.Application.Command.Pessoa
{
    public class PessoaCreaterCommand : IRequest<string>
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Telefone { get; set; }

        public int Idade { get; set; }

        public string CPF { get; set; }
    }
}
