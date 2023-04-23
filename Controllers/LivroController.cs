using ApiLivros.LivrosDbContext;
using ApiLivros.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ApiLivros.Controllers;

[ApiController]
[Route("[controller]")]
public class LivroController : ControllerBase
{
    private readonly LivroDbContext _context;

    public LivroController(LivroDbContext context)
    {
        _context = context;
    }
    [HttpGet("/")]
    public IEnumerable<Livros> ListLivros()
    {
        return _context.Livros;
    }
    [HttpGet("/{id:int}")]
    public IActionResult ListLivrosId(int id)
    {
        var livro = _context.Livros.FirstOrDefault(x => x.Id == id);

        if (livro == null)
            return NotFound();

        return Ok(livro);
    }
    [HttpPost("/")]
    public IActionResult PostLivro(
        [FromBody] Livros livros)
    {
        _context.Livros.Add(livros);
        _context.SaveChanges();

        return Created($"{livros.Id}", livros);
    }
    [HttpPut("/{id:int}")]
    public IActionResult UpdateLivro(
        [FromRoute] int id,
        [FromBody] Livros livro)
    {
        var updateLivro = _context.Livros.FirstOrDefault(x => x.Id == id);

        if (updateLivro == null) return NotFound();

        updateLivro.Titulo = livro.Titulo;
        updateLivro.Genero = livro.Genero;
        updateLivro.Autor = livro.Autor;

        _context.Livros.Update(updateLivro);
        _context.SaveChanges();

        return Ok(updateLivro);

    }

    [HttpDelete("/{id:int}")]
    public IActionResult DeleteLivro(
        [FromRoute] int id)
    {
        var removeLivro = _context.Livros.FirstOrDefault(x => x.Id == id);

        if (removeLivro == null)
            return NotFound();

        _context.Livros.Remove(removeLivro);
        _context.SaveChanges();

        return Ok(removeLivro);
    }
}
