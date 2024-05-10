namespace William.Models;

public class Funcionario {

    // Construtor
    public Funcionario
    ( string nome, string cpf) {
        Id = Guid.NewGuid().ToString();
        Nome = nome;
        Cpf = cpf;
    }

    public string? Nome { get; set;}
    public string? Cpf { get; set;}
    public string? Id { get; set;}

    public List<Folha> Folhas { get;}

    
}