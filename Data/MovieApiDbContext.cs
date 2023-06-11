using Microsoft.EntityFrameworkCore;
using MovieCrudApi.Models.Movie;

namespace MovieCrudApi.Context
{
    public class MovieApiDbContext : DbContext
    {
        public MovieApiDbContext(DbContextOptions<MovieApiDbContext> options) : base(options) { }
        public DbSet<Movie> movies { get; set; }
    }
}
