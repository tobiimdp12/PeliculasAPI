
using Microsoft.EntityFrameworkCore;
using PeliculasAPI.Models;

namespace PeliculasAPI.Data
{
    public class DataContext: DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Movies> Movies { get; set; }
        public DbSet<Genre> Genre { get; set; }
       
    }
}
