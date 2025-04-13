using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Some_API.Data.Entities;

namespace Some_API.Configurations
{
    public class MerchantConfiguration: IEntityTypeConfiguration<MerchantEntity>
    {
        public void Configure(EntityTypeBuilder<MerchantEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title)
                .HasMaxLength(255)
                .IsRequired();
            builder.Property(x => x.Status)
                .HasMaxLength(255)
                .IsRequired();
        }
    }
}
