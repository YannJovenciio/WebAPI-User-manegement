using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Domain.Entities;
using WebApplication1.Domain.Entities.UserDepartament;

namespace WebApplication1.Infrastructure.DbContex;

public class UserDbContext : DbContext
{
    public UserDbContext(DbContextOptions<UserDbContext> options)
        : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Departament> Departaments { get; set; } 

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.Entity<User>(entity =>
    //     {
    //         entity.HasKey(e => e.Id);
    //         entity.Property(e => e.Name);
    //         entity.Property(e => e.Email).IsRequired();
    //         entity.Property(e => e.Password).IsRequired();
    //     });
    // }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // aplica automaticamente todas as configurações IEntityTypeConfiguration<T> do assembly
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserDbContext).Assembly);
    }
};

public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Name);
        builder.Property(u => u.Email).IsRequired();
        builder.Property(u => u.Password).IsRequired();
        builder.Property(u => u.CreatedAt);
        builder.Property(u => u.UpdatedAt);
        

    }
}
