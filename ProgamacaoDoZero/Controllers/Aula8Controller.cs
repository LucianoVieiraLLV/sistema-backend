using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProgamacaoDoZero.Controllers
{
    [Route("api/aula8")]
    [ApiController]
    public class Aula8Controller : ControllerBase
    {
        [Route("olaMundo")]
        [HttpGet]
        public string OlaMundo()
        {
            var mensagem = "Olá Mundo via API";
            return mensagem;
        }
        [Route("olaMundoPersonalizado")]
        [HttpPost]
        public string olaMundoPersonalizado(string nome)
        {
            var mensagem = "Olá mundo via API " + nome;

            return mensagem;
        }
        [Route("somar")]
        [HttpGet]
        public string somar(int valor1, int valor2)
        {
            var soma = valor1 + valor2;
            var mensagem = "A soma é " + soma;
            return mensagem;
        }
      
    }
}
