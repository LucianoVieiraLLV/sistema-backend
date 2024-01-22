using Microsoft.AspNetCore.Mvc;
using ProgamacaoDoZero.Models;

namespace ProgamacaoDoZero.Controllers
{
    [Route("api/aula11")]
    [ApiController]
    public class Aula11Controller : ControllerBase
    {
        [Route("obterveiculo")]
        [HttpGet]
        public Veiculo obterVeiculo()
        {
            var meuVeiculo = new Veiculo();

            meuVeiculo.Cor = "amarelo";
            meuVeiculo.Marca = "ford";
            meuVeiculo.Modelo = "Fusion";
            meuVeiculo.Placa = "DEX-3358";

            meuVeiculo.Acelerar();

            return meuVeiculo;

        }
        [Route("obtercarro")]
        [HttpGet]
        public Carro obtercarro()
        {
            var meuCarro = new Carro();

            meuCarro.Marca = "Honda";
            meuCarro.Modelo = "Fit";
            meuCarro.Placa = "DRT-2352";
            meuCarro.Cor = "Prata";

            meuCarro.Acelerar();

            return meuCarro;
        }

        [Route("obtermoto")]
        [HttpGet]
        public Moto obtermoto()
        {

            var minhaMoto = new Moto();

            minhaMoto.Marca = "Honda";
            minhaMoto.Modelo = "Titan 125";
            minhaMoto.Placa = "HAC-2621";
            minhaMoto.Cor = "Prata";

            minhaMoto.Acelerar();

            return minhaMoto;


        }
    }
}
