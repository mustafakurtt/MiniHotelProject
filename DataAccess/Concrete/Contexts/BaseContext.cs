using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using DataAccess.Concrete.EntityConfigurations;

namespace DataAccess.Concrete.Contexts;

public class BaseContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("MiniHotelProject");
        //optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=MiniHotel;Trusted_Connection=true");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new RoomConfiguration());
        modelBuilder.ApplyConfiguration(new RoomConfiguration());
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<RoomType> RoomTypes { get; set; }
    public DbSet<Room> Rooms { get; set; }
}