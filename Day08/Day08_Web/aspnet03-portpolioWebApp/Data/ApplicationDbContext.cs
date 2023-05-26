using aspnet02_boardapp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace aspnet02_boardapp.Data
{
    public class ApplicationDbContext : IdentityDbContext   // 결국 DbContext 쓰는것하고 동일
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Board> Boards { get; set; }
    }
}