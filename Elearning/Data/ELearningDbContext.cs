using ElearningApplication.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ElearningApplication.Data;

public class ELearningDbContext : IdentityDbContext<ApplicationUser>
{
    public ELearningDbContext(DbContextOptions<ELearningDbContext> options) : base(options)
    {

    }

    public DbSet<Grade> Grades { get; set; } = null!;
    public DbSet<Course> Courses { get; set; } = null!;
    public DbSet<Term> Terms { get; set; } = null!;
    public DbSet<Subject> Subjects { get; set; } = null!;
    public DbSet<OriginClass> OriginClasses { get; set; } = null!;
    public DbSet<OnlineClass> OnlineClasses { get; set; } = null!;
    public DbSet<ClassDay> ClassDays { get; set; } = null!;
    public DbSet<ApplicationUser> ApplicationUsers { get; set; } = null!;

    public DbSet<SubjectOriginClass> SubjectOriginClasses { get; set; } = null!;
    public DbSet<Student> Students { get; set; } = null!;

    public DbSet<StudentClassDay> StudentClassDays { get; set; } = null!;




    protected override void OnModelCreating(ModelBuilder builder)
    {
        // grade 1 -----------> n Course
        builder.Entity<Course>()
                 .HasOne(c => c.Grade)
                 .WithMany(g => g.Courses)
                 .HasForeignKey(fk => fk.GradeId);
        // Course 1 ---------------> n Term
        builder.Entity<Term>()
                .HasOne(t=>t.Course)
                .WithMany(c=>c.Terms)
                .HasForeignKey(fk=>fk.CourseId);
        //Term 1 ----------------> n Subject.
        builder.Entity<Subject>()
                .HasOne(s=>s.Term)
                .WithMany(t=>t.Subjects)
                .HasForeignKey(fk=>fk.TermId);



        // grade 1 ---------------> n originClass
        builder.Entity<OriginClass>()
                .HasOne(oc=>oc.Grade)
                .WithMany(g=>g.originClasses)
                .HasForeignKey(fk=>fk.GradeId);


        // OriginClass n ----------------> n Subject.
        builder.Entity<SubjectOriginClass>()
                .HasOne(soc=>soc.OriginClass)
                .WithMany(oc=>oc.SubjectOriginClasses)
                .HasForeignKey(fk=>fk.OriginClassId);
        
        builder.Entity<SubjectOriginClass>()
                .HasOne(soc=>soc.OriginClass)
                .WithMany(oc=>oc.SubjectOriginClasses)
                .HasForeignKey(fk=>fk.OriginClassId);


        // subjectOriginClass 1 -----------------> 1 OnlineClass
        builder.Entity<SubjectOriginClass>()
                .HasOne(soc=>soc.OnlineClass)
                .WithOne(oc=>oc.SubjectOriginClass)
                .HasForeignKey<OnlineClass>(oc=>oc.SubjectOriginClassId);
       //
        builder.Entity<OnlineClass>()
                .HasOne(oc=>oc.originClass)
                .WithMany(originClass=>originClass.onlineClasses)
                .HasForeignKey(oc=>oc.OriginClassId);
        
        // OnlineClass 1 --------------------> n ClassDay
        builder.Entity<ClassDay>()
                .HasOne(cd=>cd.onlineClass)
                .WithMany(oc=>oc.ClassDays)
                .HasForeignKey(cd=>cd.OnlineClassId);


        //Student n --------------> n ClassDay
        builder.Entity<StudentClassDay>()
                .HasOne(scd=>scd.ClassDay)
                .WithMany(cd=>cd.StudentClassDays)
                .HasForeignKey(scd=>scd.ClassDayId);

        builder.Entity<StudentClassDay>()
                .HasOne(scd=>scd.Student)
                .WithMany(st=>st.StudentClassDays)
                .HasForeignKey(scd=>scd.StudentId);

        // OriginClass 1 ------------------> n Student
        builder.Entity<Student>()
                .HasOne(s=>s.originClass)
                .WithMany(oc=>oc.Students)
                .HasForeignKey(fk=>fk.OriginClassId);
        // Course 1 ------------------------> n student
        builder.Entity<Student>()
                .HasOne(s=>s.Course)
                .WithMany(c=>c.Students)
                .HasForeignKey(fk=>fk.CourseId);
        // grade 1 --------------------> n student
        builder.Entity<Student>()
                .HasOne(s=>s.Grade)
                .WithMany(g=>g.Students)
                .HasForeignKey(fk=>fk.GradeId);
        // student 1 --------------------->1 user count
        builder.Entity<Student>()
                .HasOne(s=>s.ApplicationUser)
                .WithOne(u=>u.Student)
                .HasForeignKey<ApplicationUser>(fk=>fk.StudentId);

        
    }
}