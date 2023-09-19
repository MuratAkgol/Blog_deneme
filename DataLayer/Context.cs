using EntityLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataLayer
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=LAPTOP-PT4JT3A9; Database=Blog; Trusted_Connection=true");
        }
        public DbSet<BlogYazilari> tbl_BlogYazilari { get; set; }
        public DbSet<Tur> tbl_turler { get; set; }
        
    }
}
