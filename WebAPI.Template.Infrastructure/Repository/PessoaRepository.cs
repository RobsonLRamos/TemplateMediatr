using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Template.Domain.Pessoa.Entity;

namespace WebAPI.Template.Infrastructure.Repository
{
    public class PessoaRepository : IPessoaRepository
    {
        public List<Pessoa> Pessoas { get; }
        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Pessoa>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Pessoa> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Save(Pessoa pessoa)
        {
            throw new NotImplementedException();
        }

        public Task Update(int id, Pessoa customer)
        {
            throw new NotImplementedException();
        }
    }
}
