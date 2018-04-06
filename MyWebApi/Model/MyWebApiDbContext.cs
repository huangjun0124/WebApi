using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MyWebApi.Model
{
    public class MyWebApiDbContext : DbContext
    {
        public MyWebApiDbContext(DbContextOptions<MyWebApiDbContext> options)
            : base(options)
        {
        }

        public DbSet<MailList> MailLists { get; set; }
        public DbSet<MyDictionary> Dictionary { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<MailList>().HasKey(ml => ml.MailListId);
            modelBuilder.Entity<MyDictionary>().HasKey(ml => ml.Key);
        }
    }
}
