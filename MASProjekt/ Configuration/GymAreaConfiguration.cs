using System;
using MASProjekt.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MASProjekt.Configuration
{
	public class GymAreaConfiguration : IEntityTypeConfiguration<GymArea>
    {
        public void Configure(EntityTypeBuilder<GymArea> builder)
        {
            
        }
    }
}

