using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebAPI.Template.Application.Command.Pessoa;
using WebAPI.Template.Application.Enum;
using WebAPI.Template.Application.Notifications.Pessoa;
using WebAPI.Template.Domain.Pessoa.Entity;
using WebAPI.Template.Infrastructure.Repository;

namespace WebAPI.Template.Application.Handler
{
    public class PessoaHandler :
        IRequestHandler<PessoaCreaterCommand, string>,
        IRequestHandler<PessoaUpdateCommand, string>,
        IRequestHandler<PessoaDeleteCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IPessoaRepository _PessoaRepository;

        public PessoaHandler(IMediator mediator, IPessoaRepository PessoaRepository)
        {
            _mediator = mediator;
            _PessoaRepository = PessoaRepository;
        }

        public async Task<string> Handle(PessoaCreaterCommand request, CancellationToken cancellationToken)
        {
            var Pessoa = new Pessoa(request.Id, request.Nome, request.Telefone, request.Idade, request.CPF);
            await _PessoaRepository.Save(Pessoa);

            await _mediator.Publish(new PessoaActionNotification
            {
                Nome = request.Nome,
                Telefone = request.Telefone,
                Idade = request.Idade,
                CPF = request.CPF,
                Action = ActionNotification.Criado
            }, cancellationToken);

            return await Task.FromResult("Cliente registrado com sucesso");
        }

        public async Task<string> Handle(PessoaUpdateCommand request, CancellationToken cancellationToken)
        {
            var Pessoa = new Pessoa(request.Id, request.Nome, request.Telefone, request.Idade, request.CPF);
            await _PessoaRepository.Update(request.Id, Pessoa);

            await _mediator.Publish(new PessoaActionNotification
            {
                Nome = request.Nome,
                Telefone = request.Telefone,
                Idade = request.Idade,
                CPF = request.CPF,
                Action = ActionNotification.Atualizado
            }, cancellationToken);

            return await Task.FromResult("Cliente atualizado com sucesso");
        }

        public async Task<string> Handle(PessoaDeleteCommand request, CancellationToken cancellationToken)
        {
            var client = await _PessoaRepository.GetById(request.Id);
            await _PessoaRepository.Delete(request.Id);

            await _mediator.Publish(new PessoaActionNotification
            {
                Nome = client.Nome,
                Telefone = client.Telefone,
                Idade = client.Idade,
                CPF = client.CPF,
                Action = ActionNotification.Excluido
            }, cancellationToken);

            return await Task.FromResult("Cliente excluido com sucesso");
        }
    }
}
