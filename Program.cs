using ApiLivros.LivrosDbContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

var connection = builder.Configuration.GetConnectionString("LivroConnection");
builder.Services.AddDbContext<LivroDbContext>(option
    => option.UseSqlServer(connection));

var app = builder.Build();

app.MapControllers();

app.Run();
