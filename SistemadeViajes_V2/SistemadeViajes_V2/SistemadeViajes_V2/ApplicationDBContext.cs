using Microsoft.EntityFrameworkCore;
using SistemadeViajes_V2.Entidades;

namespace SistemadeViajes_V2
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<colaborador> colaborador { get; set; }
    }
}
