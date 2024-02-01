using Microsoft.EntityFrameworkCore;
using TrinityAPI.Models.Game;

namespace TrinityAPI.Database.Context
{
    public class ContextGame : DbContext
    {
        public ContextGame(DbContextOptions<ContextGame> options) : base (options) 
        { 
        
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Item>().ToTable("Item").HasKey(k => k.ID);
        }
    }
}
