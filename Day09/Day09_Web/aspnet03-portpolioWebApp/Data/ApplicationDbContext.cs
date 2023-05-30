using aspnet02_boardapp.Models;
using aspnet03_portpolioWebApp.Models;
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

        // 포트폴리오를 DB로 관리하기 위한 모델
        public DbSet<PortfolioModel> Portfolios { get; set; }

        // 포트폴리오를 DB로 관리하기 위한 모델
        public DbSet<TempPortfolioModel>? TempPortfolio { get; set; }
    }
}