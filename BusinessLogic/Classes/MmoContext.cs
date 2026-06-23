using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Classes
{
    public class MmoContext : DbContext
    {
        public DbSet<MmoPlayer> MmoPlayers { get; set; }
        public DbSet<Boss> Bosses { get; set; }
        public DbSet<Mechanic> Mechanics { get; set; }
        public DbSet<ItemDrop> ItemDrops { get; set; }
        public DbSet<RaidLog> RaidLogs { get; set; }
        public DbSet<WebUser> WebUsers { get; set; }

        public string DbPath { get; }


        public MmoContext(DbContextOptions<MmoContext> options) : base(options)
        {
            DbPath = Environment.GetEnvironmentVariable("RUNNING_IN_DOCKER") == "true"
                ? "/app/mmo.db"
                : Path.Join(AppContext.BaseDirectory, "mmo.db");
        }

        public MmoContext()
        {
            DbPath = Environment.GetEnvironmentVariable("RUNNING_IN_DOCKER") == "true"
                ? "/app/mmo.db"
                : Path.Join(AppContext.BaseDirectory, "mmo.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite($"Data Source={DbPath}", b => b.MigrationsAssembly("BusinessLogic"));

        
    }
}
