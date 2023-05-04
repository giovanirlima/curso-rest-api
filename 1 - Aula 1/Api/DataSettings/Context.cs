using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.DataSettings
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options) { }

        public DbSet<Fornecedor> Forcedores { get; set; }
    }
}