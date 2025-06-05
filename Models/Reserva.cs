namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            if (diasReservados <= 0)
            {
                throw new ArgumentException("O número de dias reservados deve ser maior que zero.");
            }
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            if (Suite != null && hospedes.Count <= Suite.Capacidade)
            {
                Hospedes = hospedes;
            }
            else
            {
                throw new Exception("A quantidade de hóspedes para essa suíte é maior que sua capacidade.");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            if (Hospedes != null)
            {
                return Hospedes.Count;
            }
            return 0;
        }

        public decimal CalcularValorDiaria()
        {
            if (Suite != null)
            {
                decimal valor = DiasReservados * Suite.ValorDiaria;

                if (DiasReservados >= 10)
                {
                    valor *= 0.9M; // Aplica o desconto de 10%
                }

                return valor;
            }

            return 0;
        }
    }
}