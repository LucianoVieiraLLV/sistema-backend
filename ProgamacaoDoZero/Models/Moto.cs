
namespace ProgamacaoDoZero.Models
{
    public class Moto : Veiculo
    {
        public Moto()
        {
            QuantidadeDeRodas = 2;
            TanqueCombustivel = 15;
        }

        public override void Acelerar()
        {
            InjetarCombustivel(1);
        }

        private void InjetarCombustivel(int quantidadeCombustivel)
        {
            base.TanqueCombustivel = base.TanqueCombustivel - quantidadeCombustivel;
        }

        public int QuantidadeDeRodas { get; set; }

    }
}
