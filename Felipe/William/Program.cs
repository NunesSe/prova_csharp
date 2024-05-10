using Microsoft.AspNetCore.Mvc;
using William.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDataContext>();
var app = builder.Build();


app.MapGet("/api/funcionario/listar",
    ([FromServices] AppDataContext ctx) =>
    {
        return Results.Ok(ctx.Funcionarios);
    });

app.MapPost("/api/funcionario/cadastrar", ([FromBody] Funcionario funcionario, [FromServices] AppDataContext ctx) =>
{
    ctx.Funcionarios.Add(funcionario);
    ctx.SaveChanges();
    return Results.Created("", funcionario);
});

app.MapPost("/api/folha/cadastrar", ([FromBody] Folha folha, [FromServices] AppDataContext ctx) =>
{
    string? funcionarioId = folha.FuncionarioId;
    List<Funcionario>? funcionarios = ctx.Funcionarios.ToList();
    foreach (Funcionario funcionario in funcionarios)
    {
        Console.WriteLine(funcionarioId);
        if (funcionario.Id == funcionarioId)
        {
            folha.salarioBruto = folha.Quantidade * folha.Valor;
            if (folha.salarioBruto >= 1903.99 && folha.salarioBruto <= 2826.65)
            {
                folha.impostoIrrf = folha.salarioBruto * 0.075 - 142.80;
            }
            if (folha.salarioBruto >= 2826.66 && folha.salarioBruto <= 3751.05)
            {
                folha.impostoIrrf = folha.salarioBruto * 0.15 - 354.80;
            }
            if (folha.salarioBruto >= 3751.06 && folha.salarioBruto <= 4664.68)
            {
                folha.impostoIrrf = folha.salarioBruto * 0.225 - 636.13;
            }
            if (folha.salarioBruto > 4664.68)
            {
                folha.impostoIrrf = folha.salarioBruto * 0.275 - 869.36;
            }



            if (folha.salarioBruto <= 1693.72)
            {
                folha.impostoInss = folha.salarioBruto * 0.08;
            }
            if (folha.salarioBruto >= 1693.73 && folha.salarioBruto <= 2822.90)
            {
                folha.impostoInss = folha.salarioBruto * 0.09;

            }
            if (folha.salarioBruto >= 2822.91 && folha.salarioBruto <= 5645.80)
            {
                folha.impostoInss = folha.salarioBruto * 0.11;
            }
            if (folha.salarioBruto >= 5645.81)
            {
                folha.impostoInss = 621.03;
            }

            folha.impostoFgts = folha.salarioBruto * 0.08;

            folha.salarioLiquido = folha.salarioBruto - (folha.impostoInss + folha.impostoIrrf);
            ctx.Folhas.Add(folha);
            ctx.SaveChanges();
            return Results.Ok(folha);
        }
    }
    return Results.NotFound("Funcionario não encontrado!");
});

app.MapGet("/api/folha/listar",
    ([FromServices] AppDataContext ctx) =>
    {
        if (ctx.Folhas.ToList().Any())
        {
            return Results.Ok(ctx.Folhas);
        }

        return Results.NotFound("Não ha folhas cadastradas!");
    });

app.Run();
