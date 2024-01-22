
namespace ProgamacaoDoZero.Models
{
    public class Carro : Veiculo
    {
        public Carro()
        {
            QuantidadeDeRodas = 4;
        }
        public int QuantidadeDeRodas { get; set; }

        public override void Acelerar()
        {
            InjetarCombustivel(4);
        }
        private void InjetarCombustivel(int quantidadeCombustivel)
        {
            base.TanqueCombustivel = base.TanqueCombustivel - quantidadeCombustivel;
        }
    }
}
