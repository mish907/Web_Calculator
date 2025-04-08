using CalculatorAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CalculatorAPI.Data
{
    public class AppDBContext : DbContext
    {
        public DbSet<Calculator> storedCalculation { get; set; }

        public AppDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }
    }
}
