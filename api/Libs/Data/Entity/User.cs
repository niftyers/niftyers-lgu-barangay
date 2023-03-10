using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Niftyers;

public class User : Login
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public class Configuration : EntityConfigurationBase<User> {
        public override void Configure(EntityTypeBuilder<User> entity)
        {
            entity.HasKey(p => p.Id).HasName("IX_UserId");
            entity.HasIndex(p => p.Username).IsUnique();
            entity.Property(p => p.Name).HasDefaultValue("").HasMaxLength(80);
            entity.Property( p => p.Username).HasDefaultValue("").HasMaxLength(30);
            entity.Property(p => p.Password).HasDefaultValue("").HasMaxLength(30);
            entity.ToTable("Users");
        }
    }
    
}