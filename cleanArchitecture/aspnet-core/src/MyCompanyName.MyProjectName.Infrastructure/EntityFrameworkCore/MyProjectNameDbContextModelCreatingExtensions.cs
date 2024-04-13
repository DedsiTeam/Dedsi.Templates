using Microsoft.EntityFrameworkCore;
using MyCompanyName.MyProjectName.Samples;
using Volo.Abp;

namespace MyCompanyName.MyProjectName.EntityFrameworkCore;

public static class MyProjectNameDbContextModelCreatingExtensions
{
    public static void ConfigureMyProjectName(this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));

        builder.Entity<Sample>(b =>
        {
            b.ToTable("Sample", "dbo");
            b.HasKey(a => a.Id);
        });
    }
}