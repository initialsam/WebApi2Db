using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace MDB1Repository.Mapping;

public class DeeplinkLogConfiguration : IEntityTypeConfiguration<DeeplinkLog>
{
    public void Configure(EntityTypeBuilder<DeeplinkLog> builder)
    {
        builder.ToTable("DeeplinkLog");

        builder.HasKey(x => x.SeqNo).IsClustered(true);
        builder.Property(x => x.SeqNo).IsRequired(true).ValueGeneratedOnAdd();

        builder.Property(x => x.Topic).HasMaxLength(100).IsRequired(true);
        builder.Property(x => x.OsType).HasMaxLength(100).IsRequired(true);
        builder.Property(x => x.Source).HasMaxLength(100).IsRequired(true);
        builder.Property(x => x.Medium).HasMaxLength(100).IsRequired(true);

        builder.Property(x => x.CreateTime).IsRequired(true);

        builder.HasIndex(x => x.Topic).IsClustered(false);
        builder.HasIndex(x => x.Source).IsClustered(false);
    }
}
