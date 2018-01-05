using Microsoft.EntityFrameworkCore;
using MoviesApp.Models;

namespace MoviesApp.Data
{
    public class MovieContext : DbContext
    {
      public MovieContext(DbContextOptions<MovieContext> options) : base(options)
      {
      }

      public DbSet<Movie> Movies { get; set; }
    }
}
