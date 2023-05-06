using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace DevIO.Data.ContextDB
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options) { }

        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
    }
}