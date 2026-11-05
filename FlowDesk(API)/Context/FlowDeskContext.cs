using FlowDesk_API_.Modelos;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FlowDesk_API_.Context
{
    public class FlowDeskContext : IdentityDbContext<Usuario>
    {

        public FlowDeskContext(DbContextOptions<FlowDeskContext> opts) : base(opts)
        {

        }

        public DbSet<Chamado> Chamados { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
    }
}
