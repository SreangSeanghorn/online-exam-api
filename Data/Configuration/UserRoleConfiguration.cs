using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TodoApi.Data.Configuration
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "b2636901-9c81-4866-aaa4-508045007200",
                    UserId = "1"
                }, new IdentityUserRole<string>
                {
                    RoleId = "c51ddc58-9c51-4ece-9def-dc1431f1e207",
                    UserId = "2"
                }
                
            );
        }
    }
}