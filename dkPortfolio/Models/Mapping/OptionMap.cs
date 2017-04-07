using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace dkPortfolio.Models.Mapping
{
    public class OptionMap : EntityTypeConfiguration<Option>
    {
        public OptionMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.oBook)
                .HasMaxLength(200);

            this.Property(t => t.oUser)
                .HasMaxLength(200);

            this.Property(t => t.oFire)
                .HasMaxLength(200);

            this.Property(t => t.oGlobe)
                .HasMaxLength(200);

            this.Property(t => t.oThinking)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("Options");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.oBook).HasColumnName("oBook");
            this.Property(t => t.oUser).HasColumnName("oUser");
            this.Property(t => t.oFire).HasColumnName("oFire");
            this.Property(t => t.oGlobe).HasColumnName("oGlobe");
            this.Property(t => t.oThinking).HasColumnName("oThinking");
        }
    }
}
