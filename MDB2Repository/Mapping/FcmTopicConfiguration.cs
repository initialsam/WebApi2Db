using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace MDB2Repository.Mapping;

public class FcmTopicConfiguration : IEntityTypeConfiguration<FcmTopic>
{
    public void Configure(EntityTypeBuilder<FcmTopic> builder)
    {
        builder.ToTable("FcmTopic");
        builder.HasKey(x => x.SeqNo);

        builder.Property(x => x.SeqNo).IsRequired().ValueGeneratedOnAdd();
        builder.Property(x => x.TopicName).IsUnicode(false).HasMaxLength(100).IsRequired(true);
        builder.Property(x => x.Count).IsRequired(true);
    }
}