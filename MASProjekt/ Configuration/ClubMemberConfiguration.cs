using System;
using MASProjekt.Data;
using MASProjekt.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MASProjekt.Configuration
{
	public class ClubMemberConfiguration : IEntityTypeConfiguration<ClubMember>
    {
        public void Configure(EntityTypeBuilder<ClubMember> builder)
        {
            
        }
    }
}

