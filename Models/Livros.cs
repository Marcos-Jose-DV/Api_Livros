using System.ComponentModel.DataAnnotations;

namespace ApiLivros.Models;

public class Livros
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required]
    [MaxLength(100, ErrorMessage = "O Titulo e obrigatorio")]
    public string Titulo { get; set; }

    [Required]
    [MaxLength(100, ErrorMessage = "O Gênero e obrigatorio")]
    public string Genero { get; set; }

    [Required]
    [MaxLength(100, ErrorMessage = "O Autor e obrigatorio")]
    public string Autor { get; set; }

    public DateTime DataPublicacao { get; set; }
}
