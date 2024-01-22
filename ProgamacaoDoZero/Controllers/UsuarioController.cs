
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ProgamacaoDoZero.Models;
using ProgamacaoDoZero.Services;

namespace ProgamacaoDoZero.api.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IConfiguration _configuration;
        public UsuarioController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [Route("login")]
        [HttpPost]
        public LoginResult Login(LoginRequest request)
        {
            var result = new LoginResult();

            if (request == null)
            {
                result.sucesso = false;
                result.mensagem = "parametro request veio nulo.";
            }
            else if (request.email == "")
            {

                result.sucesso = false;
                result.mensagem = "email obrigatorio";
            }
            else if (request.email == "")
            {

                result.sucesso = false;
                result.mensagem = "senha obrigatoria";
            }

            else
            {
                var connectionString = _configuration.GetConnectionString("programacaoDoZeroDB");

                var usuarioService = new UsuarioService(connectionString);

                result = usuarioService.Login(request.email, request.senha);

            }
            return result;
        }

        [Route("cadastro")]
        [HttpPost]
        public CadastroResult Cadastro(CadastroRequest request)
        {
            var result = new CadastroResult();

            if (request == null ||
                string.IsNullOrEmpty(request.nome) ||
                string.IsNullOrEmpty(request.sobrenome) ||
                string.IsNullOrEmpty(request.telefone) ||
                string.IsNullOrEmpty(request.genero) ||
                string.IsNullOrEmpty(request.email) ||
                string.IsNullOrEmpty(request.senha))
            {
                result.sucesso = false;

                result.mensagem = "Todos os campos são obrigatorios";

            }
            else
            {
                var connectionString = _configuration.GetConnectionString("programacaoDoZeroDB");

                var usuarioService = new UsuarioService(connectionString);

                result = usuarioService.Cadastro(request.nome,
                    request.sobrenome,
                    request.telefone,
                    request.email,
                    request.genero,
                    request.senha);

            }

            return result;
        }

        [Route("EsqueceuSenha")]
        [HttpPost]
        public EsqueceuSenhaResult EsqueceuSenha(EsqueceuSenhaRequest request)
        {
            var result = new EsqueceuSenhaResult();

            if (request == null ||
                string.IsNullOrEmpty(request.email))
            {
                result.mensagem = "E-mail obrigatorio";
                return result;
            }

                var connectionString = _configuration.GetConnectionString("programacaoDoZeroDB");

            result = new UsuarioService(connectionString).EsqueceuSenha(request.email);


            return result;
        }

        [HttpGet]
        [Route("obterUsuario")]
        public ObterUsuarioResult ObterUsuario(Guid usuarioGuid)
        {
            var result = new ObterUsuarioResult();

            if (usuarioGuid == null)
            {
                result.mensagem = "Guid vazio";
            }
            else
            {
                var connectionString = _configuration.GetConnectionString("programacaoDoZeroDb");
                var usuario = new UsuarioService(connectionString).ObterUsuario(usuarioGuid);

                if (usuario == null)
                {
                    result.mensagem = "Usuario não existe";
                }
                else{
                    result.sucesso = true;
                    result.nome = usuario.Nome;
                }

            }
            return result;
        }
    }
}