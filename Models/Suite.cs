namespace DesafioProjetoHospedagem.Models
{
    public class Suite
    {
        public Suite() { }

        public Suite(string tipoSuite, int capacidade, decimal valorDiaria)
        {
            TipoSuite = tipoSuite;
            if (capacidade <= 0)
            {
                throw new ArgumentException("A capacidade deve ser maior que zero.");
            }
            Capacidade = capacidade;
            if (valorDiaria <= 0)
            {
                throw new ArgumentException("O valor da diária deve ser maior que zero.");
            }
            ValorDiaria = valorDiaria;
        }

        public string TipoSuite { get; set; }
        public int Capacidade { get; set; }
        public decimal ValorDiaria { get; set; }
    }
}