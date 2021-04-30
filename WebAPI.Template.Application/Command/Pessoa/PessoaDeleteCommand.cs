using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Template.Application.Command.Pessoa
{
    public class PessoaDeleteCommand : IRequest<string>
    {
        public int Id { get; set; }
    }
}
