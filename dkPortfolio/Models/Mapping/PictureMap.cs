using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace dkPortfolio.Models.Mapping
{
    public class PictureMap : EntityTypeConfiguration<Picture>
    {
        public PictureMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Path)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Name)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Picture");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Path).HasColumnName("Path");
            this.Property(t => t.Name).HasColumnName("Name");
        }
    }
}
