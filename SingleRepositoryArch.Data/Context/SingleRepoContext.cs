using Microsoft.EntityFrameworkCore;
using SingleRepositoryArch.Data.Models.Management;

namespace SingleRepositoryArch.Infra.Data;

public class SingleRepoContext : DbContext
{
    public SingleRepoContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Teacher> teachers { get; set; }
    public DbSet<TeacherDetails> teacherDetails { get; set; }
    public DbSet<Semester> semesters { get; set; }
    public DbSet<SemesterSchedule> semesterSchedule { get; set; }

}


