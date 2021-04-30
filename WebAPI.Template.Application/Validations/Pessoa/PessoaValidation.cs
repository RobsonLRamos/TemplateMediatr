using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Template.Application.Command.Pessoa;

namespace WebAPI.Template.Application.Validations.Pessoa
{
    public class PessoaValidation : AbstractValidator<PessoaCreaterCommand>
    {

        public PessoaValidation()
        {

        }
    }
}
