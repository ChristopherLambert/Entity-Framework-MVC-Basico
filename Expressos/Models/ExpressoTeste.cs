using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Expressos.Models
{
    public class Livro
    {
        [Key]
        public int LivroId { get; set; }

        public int AutorId { get; set; }
        [ForeignKey("AutorId")]
        public Autor Autor { get; set; }

        public int EditoraId { get; set; }
        [ForeignKey("EditoraId")]
        public Editora Editora { get; set; }

        public string Titulo { get; set; }
        public int AnoLancamento { get; set; }
    }
    public class Autor
    {
        [Key]
        public int AutorId { get; set; }
        public string Nome { get; set; }
        public DateTime DataDeNacimento { get; set; }

        public ICollection<Livro> Livros { get; set; }
    }

    public class Editora
    {
        [Key]
        public int EditoraId { get; set; }
        public string Nome { get; set; }

        public ICollection<Livro> Livros { get; set; }
    }
}