namespace Questao5
{

    public class ContaCorrente
    {
        public string? IdContacorrente { get; set; }
        public int Numero { get; set; }
        public string? Nome { get; set; }
        public bool Ativo { get; set; }
        public int Valor { get; set; }
    }
    public class MovimentoContaCorrente
    {
        public string? IdMovimento { get; set; }
        public string? IdContacorrente { get; set; }
        public DateTime Data { get; set; }
        public string? TipoMovimento { get; set; }
        public Single Valor { get; set; }
    }
}