using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Template.Domain.Pessoa.Entity;

namespace WebAPI.Template.Infrastructure.Repository
{
    public interface IPessoaRepository
    {
        Task Save(Pessoa pessoa);
        Task Update(int id, Pessoa customer);
        Task Delete(int id);
        Task<Pessoa> GetById(int id);
        Task<IEnumerable<Pessoa>> GetAll();
    }
}
