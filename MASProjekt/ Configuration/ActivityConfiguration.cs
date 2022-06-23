using System;
using MASProjekt.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MASProjekt.Configuration
{
	public class ActivityConfiguration : IEntityTypeConfiguration<Activity>
	{
        public void Configure(EntityTypeBuilder<Activity> builder)
        {
            builder.HasKey(e => e.ID).HasName("Activity_PK");

            builder.Property(e => e.ID).UseIdentityColumn();

            builder.Property(e => e.Title).IsRequired();

            builder.Property(e => e.Description).IsRequired();

            builder.Property(e => e.Start).IsRequired();

            builder.Property(e => e.End).IsRequired();

            builder.HasOne(d => d.Trainer)
                .WithMany(d => d.Activities)
                .HasForeignKey(d => d.TrainerId)
                .OnDelete(DeleteBehavior.Cascade);

            var activities = new List<Activity>();

            activities.Add(new Activity
            {
                ID = 1,
                Title = "Zamba",
                Description = "Tanczymy do rana",
                Start = DateTime.UtcNow,
                End = DateTime.Now,
                TrainerId = 1
            });

            activities.Add(new Activity
            {
                ID = 1,
                Title = "Umba",
                Description = "Skaczemy do rana",
                Start = DateTime.UtcNow,
                End = DateTime.Now,
                TrainerId = 2
            });

            builder.HasData(activities);
        }
    }
}

