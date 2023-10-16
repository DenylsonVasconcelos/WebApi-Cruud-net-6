using APICrud.Map;
using APICrud.Models;
using Microsoft.EntityFrameworkCore;

namespace APICrud.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base (options) { }

    public DbSet<Pessoa> Pessoas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PessoaMap());
        base.OnModelCreating(modelBuilder);
    }

}


