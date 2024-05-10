namespace William.Models;

public class Folha {
    public Folha
    ( double valor, int quantidade, int mes, int ano) {
        Id = Guid.NewGuid().ToString();
        Valor = valor;
        Quantidade = quantidade;
        Mes = mes;
        Ano = ano;
    }
    public string Id { get; set;}
    public double Valor { get; set;}
    public int Quantidade { get; set;}
    public int Mes { get; set;}
    public int Ano { get; set;}
    public string  FuncionarioId { get; set;}
    public Funcionario Funcionario { get; set;}

    public double salarioBruto {get; set;}
    public double impostoIrrf {get; set;}
    public double impostoInss {get; set;}
    public double impostoFgts {get; set;}
    public double salarioLiquido {get; set;}
}