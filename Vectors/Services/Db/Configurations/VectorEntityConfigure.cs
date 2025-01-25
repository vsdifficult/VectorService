using Vectors; 
using Microsoft.EntityFrameworkCore; 
using Microsoft.EntityFrameworkCore.Metadata.Builders; 

public class VectorConfigurations: IEntityTypeConfiguration<Table> 
{ 
    public void Configure(EntityTypeBuilder<Table> builder)
    { 
        builder.ToTable("Vectors");  
        builder.HasKey(i => i.Id); 
    }
}