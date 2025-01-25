using Microsoft.EntityFrameworkCore; 

namespace Vectors 
{ 
    public class VectorsDbContext: DbContext 
    { 
        public DbSet<Table> vectors {get; set;} 
        public VectorsDbContext(DbContextOptions<VectorsDbContext> voptions) : base(voptions){}
        protected private void OModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 
            modelBuilder.ApplyConfiguration(new VectorConfigurations()); 
        }
    } 
}