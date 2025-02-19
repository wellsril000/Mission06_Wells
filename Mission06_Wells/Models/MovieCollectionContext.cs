using Microsoft.EntityFrameworkCore;

namespace Mission06_Wells.Models;

public class MovieCollectionContext: DbContext // inherit from DbContext 
{
    public MovieCollectionContext(DbContextOptions<MovieCollectionContext> options) : base(options) // create a constructor 
    {
        
    } 
    
    public DbSet<NewMovie> Movies { get; set; }
    
}