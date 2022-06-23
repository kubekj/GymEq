using System;
using MASProjekt.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MASProjekt.Configuration
{
	public class MaidConfiguration : IEntityTypeConfiguration<Maid>
    {
		public void Configure(EntityTypeBuilder<Maid> builder)
        {
            
        }
    }
}

