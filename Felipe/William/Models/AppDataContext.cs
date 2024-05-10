using Microsoft.EntityFrameworkCore;

namespace William.Models;

public class AppDataContext : DbContext
{
  
    public DbSet<Folha> Folhas { get; set; }
    public DbSet<Funcionario> Funcionarios { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=felipe_william.db");
    }
}