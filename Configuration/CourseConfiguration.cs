using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RelationshipEF.Model;

namespace RelationshipEF.Configuration
{
    public class CourseConfiguration : IEntityTypeConfiguration<CourseEntity>
    {
        public void Configure(EntityTypeBuilder<CourseEntity> builder)
        {
            builder.HasKey(c => c.Id);

            builder
                .HasOne(c => c.Author)
                .WithOne(a => a.Course)
                .HasForeignKey<CourseEntity>(l => l.AuthorId);

            builder
                .HasMany(c => c.Lessons)
                .WithOne(l => l.Course)
                .HasForeignKey(l => l.CourseId);

            builder
                .HasMany(c => c.Students)
                .WithMany(s => s.Courses);
        }
    }
}
