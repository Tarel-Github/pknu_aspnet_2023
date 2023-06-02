using Portfolio.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Portfolio.Data
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