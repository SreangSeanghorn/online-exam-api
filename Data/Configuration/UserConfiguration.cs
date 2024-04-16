using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TodoApi.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.HasData(
                new Users
                {
                    Id = "1",
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    Email = "s.seanghorn123@gmail.com",
                    NormalizedEmail = "s.seanghorn123@gmail.com",
                    EmailConfirmed = true,
                    PasswordHash = new PasswordHasher<Users>().HashPassword(null, "123"),
                    SecurityStamp = string.Empty,
                    Fullname = "Administator",
                    DateOfBirth = new DateTime(1998, 1, 1)
                }, new Users
                {
                    Id = "2",
                    UserName = "ssh",
                    NormalizedUserName = "USER",
                    Email = "ss@gmail.com",
                    NormalizedEmail = "sseanghorn@gmail.ocm",
                    EmailConfirmed = true,
                    PasswordHash = new PasswordHasher<Users>().HashPassword(null, "123"),
                    SecurityStamp = string.Empty,
                    Fullname = "ssh",
                    DateOfBirth = new DateTime(1998, 1, 1)
                }
            );
        }
           
    }
}