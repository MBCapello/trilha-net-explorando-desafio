namespace DesafioProjetoHospedagem.Models;

public class Pessoa
{
    public Pessoa(string nome, string sobrenome)
    {
        if (string.IsNullOrWhiteSpace(nome) || nome.Length < 3 || nome.Any(c => !char.IsLetter(c) && !char.IsWhiteSpace(c)))
        {
            throw new ArgumentException("Nome inválido. O nome deve conter pelo menos 3 caracteres e não pode conter números ou caracteres especiais.");
        }
        Nome = nome;
        if (string.IsNullOrWhiteSpace(sobrenome) || sobrenome.Length < 3 || sobrenome.Any(c => !char.IsLetter(c) && !char.IsWhiteSpace(c)))
        {
            throw new ArgumentException("Sobrenome inválido. O sobrenome deve conter pelo menos 3 caracteres e não pode conter números ou caracteres especiais.");
        }
        Sobrenome = sobrenome;
    }

    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public string NomeCompleto => $"{Nome} {Sobrenome}".ToUpper();
}