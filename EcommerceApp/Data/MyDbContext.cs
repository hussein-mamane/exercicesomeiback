using EcommerceApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.Data;

public class MyDbContext:DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options):base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
}
