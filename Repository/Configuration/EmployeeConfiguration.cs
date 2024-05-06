using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasData
                (
                    new Employee
                    {
                        Id = Guid.NewGuid(),
                        Name = "Denish Makadiya",
                        Position ="Sr. UnityDeveloper",
                        Age = 34,
                        CompanyId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870")
                    },
                    new Employee
                    {
                        Id = Guid.NewGuid(),
                        Name = "Pawan Rajput",
                        Position ="UnityDeveloper",
                        Age = 26,
                        CompanyId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870")
                    },
                    new Employee
                    {
                        Id = Guid.NewGuid(),
                        Name = "Sachin Tomar",
                        Position ="Frontend Developer",
                        Age = 25,
                        CompanyId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870")
                    },
                    new Employee
                    {
                        Id = Guid.NewGuid(),
                        Name = "Rahul Tripathi",
                        Position ="Administrator",
                        Age = 28,
                        CompanyId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3")
                    }
                );
        }
    }
}
