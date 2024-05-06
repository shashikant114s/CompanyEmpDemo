﻿using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasData
                (
                    new Company
                    {
                        Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                        Name = "IT_Solutions Ltd",
                        Address = "Gali no.420, Thaltej, Ahmedabad 380058",
                        Country = "IND"
                    },
                    new Company
                    {
                        Id = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                        Name = "Admin_Solutions Ltd",
                        Address = "Gali no.251, Shilaj, Ahmedabad 380059",
                        Country = "IND"
                    }
                );
        }
    }
}
