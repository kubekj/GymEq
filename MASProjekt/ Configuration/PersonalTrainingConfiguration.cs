using System;
using MASProjekt.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MASProjekt.Configuration
{
	public class PersonalTrainingConfiguration : IEntityTypeConfiguration<PersonalTraining>
    {
		public void Configure(EntityTypeBuilder<PersonalTraining> builder)
        {
            
        }
    }
}

