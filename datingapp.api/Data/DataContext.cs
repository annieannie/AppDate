using Microsoft.EntityFrameworkCore;
using datingapp.api.Models;

namespace datingapp.api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base (options)
        {          
        }
        public DbSet<Value> Values  {get;set;} 
    }
}