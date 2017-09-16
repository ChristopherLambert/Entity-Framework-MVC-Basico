using System;
using System.Data.Entity;
using Expressos.Models;

namespace Expressos
{
    public class ExpressosContext : DbContext
    {
        public DbSet<Autor> autor { get; set; }
        public DbSet<Livro> livro { get; set; }
        public DbSet<Editora> editora { get; set; }

        public ExpressosContext() : base("name=ExpressosContext")
        {
           
        }
    }
}