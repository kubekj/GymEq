using System;
using MASProjekt.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MASProjekt.Configuration
{
	public class TrainerConfiguration : IEntityTypeConfiguration<Trainer>
    {
		public void Configure(EntityTypeBuilder<Trainer> builder)
        {
            
        }
    }
}

