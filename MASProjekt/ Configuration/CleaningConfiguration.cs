using System;
using MASProjekt.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MASProjekt.Configuration
{
	public class CleaningConfiguration : IEntityTypeConfiguration<Cleaning>
    {
        public void Configure(EntityTypeBuilder<Cleaning> builder)
        {
            builder.HasKey(e => e.ID).HasName("Cleaning_PK");

            builder.Property(e => e.ID).UseIdentityColumn();

            builder.Property(e => e.DoneAt).IsRequired();

            builder.Property(e => e.EndedAt).IsRequired();

            builder.Property(e => e.MaterialsUsed).IsRequired();

            builder.HasOne(d => d.Maid)
                .WithMany(d => d.Cleanings)
                .HasForeignKey(d => d.MaidId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

