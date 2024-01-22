using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProgamacaoDoZero.Common;
using ProgamacaoDoZero.Entities;
using ProgamacaoDoZero.Models;
using ProgamacaoDoZero.Repositories;
using Microsoft.Extensions.Configuration;

namespace ProgamacaoDoZero.Services
{
    public class UsuarioService
    {
        private string _connectionString;
        public UsuarioService(string connectionString)
        {
            _connectionString = connectionString;
        }
        public LoginResult Login(string email, string senha)
        {
            var result = new LoginResult();

            var usuario = new UsuarioRepository(_connectionString).ObterUsuarioPorEmail(email);

            if (usuario != null)
            {
                if (usuario.Senha == senha)
                {       //faz login
                    result.sucesso = true;
                    result.UsuarioGuid = usuario.UsuarioGuid;
                }
                else
                {
                    result.sucesso = false;
                    result.mensagem = "Usuário ou senha invalidos ";
                }
            }
                
                       else
                    {
                        result.sucesso = false;
                        result.mensagem = "Usuário ou senha invalidos ";
                    }
         
            return result;
        }
        public CadastroResult Cadastro(string nome, string sobrenome, string telefone, string email, string genero, string senha)
        {
            var result = new CadastroResult();

            var usuarioRepository = new UsuarioRepository(_connectionString);

            var usuario = usuarioRepository.ObterUsuarioPorEmail(email);

            if(usuario!= null)
            {
                //usuario ja existe 
                result.sucesso = false;
                result.mensagem = "Usuário ja existe no sistema";
            }
            else
            {
                //usuario nao existe
                usuario = new Entities.Usuario();
                usuario.Nome = nome;
                usuario.Sobrenome = sobrenome;
                usuario.Telefone = telefone;
                usuario.Genero = genero;
                usuario.Email = email;
                usuario.Senha = senha;
                usuario.UsuarioGuid = Guid.NewGuid();

               var affectedRows =  usuarioRepository.Inserir(usuario);

                if (affectedRows > 0)
                {
                    //inseriu com sucesso
                    result.sucesso = true;
                    result.usuarioGuid = usuario.UsuarioGuid;
                }
                else
                {
                    //erro ao inserir
                    result.sucesso = false;
                    result.mensagem = "Erro ao inserir usuario tente novamente";
                }
            }

            return result;
        }
        public EsqueceuSenhaResult EsqueceuSenha(string email)
        {
            var result = new EsqueceuSenhaResult();

            var usuarioRepository = new UsuarioRepository(_connectionString);

            var usuario = usuarioRepository.ObterUsuarioPorEmail(email);

            if (usuario == null)
            {
                //não existe
                result.sucesso = false;
                result.mensagem = "Usuário não existe";

            }
            else
            {
                //usuario existe
                var emailSender = new EmailSender();

                var assunto = "Recuperação de senha";
                var corpo = "Sua senha é " + usuario.Senha;
                emailSender.Enviar(assunto, corpo , usuario.Email);

                result.sucesso = true;

            }

            return result;
        }

        public Usuario ObterUsuario(Guid usuarioGuid)
        {
            var usuario = new UsuarioRepository(_connectionString).ObterPorGuid(usuarioGuid);

            return usuario;

        }
  }
}