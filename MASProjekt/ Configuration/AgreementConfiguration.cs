using System;
using MASProjekt.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MASProjekt.Configuration
{
	public class AgreementConfiguration : IEntityTypeConfiguration<Agreement>
    {
        public void Configure(EntityTypeBuilder<Agreement> builder)
        {
            builder.HasKey(e => new {e.IdGym, e.IdPerson}).HasName("Agreement_PK");

            builder.ToTable("Agreement");

            builder.HasOne(d => d.Gym)
                .WithMany(d => d.Agreements)
                .HasForeignKey(d => d.IdGym)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(d => d.Person)
                .WithMany(d => d.Agreements)
                .HasForeignKey(d => d.IdPerson)
                .OnDelete(DeleteBehavior.Cascade);

            var agreements = new List<Agreement>();

            agreements.Add(new Agreement { IdGym = 1, IdPerson = 1, AgreementType = AgreementType.Client, SignUpDate = DateTime.Now });
            agreements.Add(new Agreement { IdGym = 1, IdPerson = 2, AgreementType = AgreementType.Employee, SignUpDate = DateTime.UtcNow });

            builder.HasData(agreements);
        }
    }
}

