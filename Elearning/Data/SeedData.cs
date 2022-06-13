using ElearningApplication.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ElearningApplication.Data;

public class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new ELearningDbContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<ELearningDbContext>>()))
        {
            if(context.ApplicationRoles.Any()) return;

            context.ApplicationRoles.AddRange(
                new ApplicationRole {Name="ADMIN",NormalizedName="ADMIN"},
                new ApplicationRole {Name="STUDENT",NormalizedName="STUDENT"},
                new ApplicationRole {Name="TEACHER",NormalizedName="TEACHER"},
                new ApplicationRole {Name="LEADERSHIP",NormalizedName="LEADERSHIP"}
            );

            context.SaveChanges();
        }
    }
}