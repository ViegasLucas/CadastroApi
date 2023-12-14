using CadastroPessoaApi.Service;
using CadastroPessoaApi.ViewModel;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace CadastroPessoaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {

        [HttpGet("GetAll")]
        public IEnumerable<PessoaViewModel> GetAll()
        {
            var service = new ServicePessoa();
            return service.GetAll();
        }

        [HttpGet("GetById/{pessoaId}")]
        public PessoaViewModel GetById(int pessoaId)
        {
            var service = new ServicePessoa();
            return service.GetById(pessoaId);
        }

        [HttpGet("GetByPrimeiroNome/{primeiroNome}")]
        public PessoaViewModel GetByPrimeiroNome(string primeiroNome)
        {
            var service = new ServicePessoa();
            return service.GetByPrimeiroNome(primeiroNome);
        }

        [HttpPut("UpdateFirstName")]
        public void UpdateFirstName(int pessoaId, string primeiroNome)
        {
            var service = new ServicePessoa();
            service.UpdateFirstName(pessoaId, primeiroNome);
        }
        [HttpPost("Create")]

        public ActionResult Create(PessoaViewModel pessoa)
        {
            var service = new ServicePessoa();
            var resultado = service.Create(pessoa);
            if(resultado == null)
            {
                var result = new
                {
                    Sucess = true,
                    Data = "Cadastro Realizado com sucesso",
                };
                return Ok(result);
            }
            else
            {
                var result = new
                {
                    Sucess = false,
                    Data = resultado.mensagem,
                };
                return Ok(result);
            }

        }

        [HttpDelete("Delete/{pessoaId}")]
        public ActionResult Delete(int pessoaId)
        {
            var service = new ServicePessoa();
            var resultado = service.Delete(pessoaId);

            if (resultado == null)
            {
                var result = new
                {
                    Success = true,
                    Data = "Exclusão realizada com sucesso",
                };
                return Ok(result);
            }
            else
            {
                var result = new
                {
                    Success = false,
                    Data = resultado.Mensagem,
                };
                return Ok(result);
            }
        }


    }
}
