using ApiLivros.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiLivros.LivrosDbContext;

public class LivroDbContext : DbContext
{
    public LivroDbContext(DbContextOptions<LivroDbContext> options)
        : base(options)
    {
        
    }
    public DbSet<Livros> Livros { get; set; }

}
