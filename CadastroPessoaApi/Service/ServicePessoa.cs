using CadastroPessoaApi.Controllers;
using CadastroPessoaApi.Data;
using CadastroPessoaApi.ViewModel;

namespace CadastroPessoaApi.Service
{
    public class ServicePessoa
    {
        public IEnumerable<PessoaViewModel> GetAll()
        {
            var repository = new Repository();
            return repository.GetAll().ToList();
        }
        public PessoaViewModel GetById(int pessoaId)
        {
            var repository = new Repository();
            return repository.GetById(pessoaId);
        }

        public PessoaViewModel GetByPrimeiroNome(string primeiroNome)
        {
            var repository = new Repository();
            return repository.GetByPrimeiroNome(primeiroNome);
        }

        public void UpdateFirstName(int pessoaId, string primeiroNome)
        {
            var respository = new Repository();
            respository.UpdateFirstName(pessoaId, primeiroNome);
        }

        public dynamic Create(PessoaViewModel pessoa)
        {
            if (pessoa == null)
                return "Os dados são obrigatórios";
            if (pessoa != null && string.IsNullOrEmpty(pessoa.nomeMeio))
                return "O campo nomeMeio é obrigatório";
            if (pessoa != null && string.IsNullOrEmpty(pessoa.ultimoNome))
                return "O campo ultimoNome é obrigatório";
            if(pessoa != null && string.IsNullOrEmpty(pessoa.CPF))
                return "O campo CPF é obrigatório";

            var repository = new Repository();
            return repository.Create(pessoa);

        }
        public dynamic Delete(int pessoaId)
        {
            if (pessoaId <= 0)
                return "ID inválido";

            var repository = new Repository();
            return repository.Delete(pessoaId);
        }

    }
}
