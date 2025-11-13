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

        public string DbPath { get; }


        public MmoContext(DbContextOptions<MmoContext> options) : base(options)
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "mmo.db");
        }

        public MmoContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "mmo.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}", b => b.MigrationsAssembly("BusinessLogic"));

        
    }
}
