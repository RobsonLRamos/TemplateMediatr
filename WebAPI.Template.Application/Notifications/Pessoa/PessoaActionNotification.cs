using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Template.Application.Enum;

namespace WebAPI.Template.Application.Notifications.Pessoa
{
    public class PessoaActionNotification : INotification
    {
        public string Nome { get; set; }

        public string Telefone { get; set; }

        public int Idade { get; set; }

        public string CPF { get; set; }

        public ActionNotification Action { get; set; }
    }
}
