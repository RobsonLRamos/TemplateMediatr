using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Template.Application.Command.Pessoa;
using WebAPI.Template.Application.Validations.Pessoa;
using WebAPI.Template.Infrastructure.Repository;

namespace WebAPI.Template.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IPessoaRepository _pessoaRepository;

        public PessoaController(IMediator mediator, IPessoaRepository pessoaRepository)
        {
            _mediator = mediator;
            _pessoaRepository = pessoaRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Post(PessoaCreaterCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(PessoaUpdateCommand command)
        {

            var validacoes = new PessoaValidation();
            var result = validacoes.Validate(command);
            if (!result.IsValid)
            {
                return BadRequest(result);
            }
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var dto = new PessoaDeleteCommand { Id = id };
            var result = await _mediator.Send(dto);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _pessoaRepository.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _pessoaRepository.GetById(id);
            return Ok(result);
        }
    }
}

