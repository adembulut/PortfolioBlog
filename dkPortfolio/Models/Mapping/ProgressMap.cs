using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace dkPortfolio.Models.Mapping
{
    public class ProgressMap : EntityTypeConfiguration<Progress>
    {
        public ProgressMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("Progress");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Data).HasColumnName("Data");
            this.Property(t => t.Value).HasColumnName("Value");
        }
    }
}
