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
    public DbSet<Teacher> Teachers { get; set; } = null!;
    public DbSet<Message> Messages { get; set; } = null!;
    public DbSet<Question> Questions { get; set; } = null!;
    public DbSet<Answer> Answers { get; set; } = null!;




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
        // techer 1 --------------------> n SubjectOriginClass
        builder.Entity<SubjectOriginClass>()
                .HasOne(soc=>soc.Teacher)
                .WithMany(t=>t.SubjectOriginClasses)
                .HasForeignKey(fk=>fk.TeacherId);
       //
        builder.Entity<OnlineClass>()
                .HasOne(oc=>oc.originClass)
                .WithMany(originClass=>originClass.onlineClasses)
                .HasForeignKey(oc=>oc.OriginClassId);

        // techer 1 -----------------> n onlineClass
        builder.Entity<OnlineClass>()
                .HasOne(oc=>oc.Teacher)
                .WithMany(t=>t.OnlineClasses)
                .HasForeignKey(fk=>fk.TeacherId);

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

        // teacher 1------------------------>1 account

        builder.Entity<Teacher>()
                .HasOne(t=>t.ApplicationUser)
                .WithOne(u=>u.Teacher)
                .HasForeignKey<ApplicationUser>(fk=>fk.TeacherId);


        // onlineClass 1-----------------------> n Message
        builder.Entity<Message>()
                .HasOne(m=>m.OnlineClass)
                .WithMany(oc=>oc.Messages)
                .HasForeignKey(fk=>fk.OnlineClassId);

        // student 1 -----------------------> n message
        builder.Entity<Message>()
                .HasOne(m=>m.Student)
                .WithMany(s=>s.Messages)
                .HasForeignKey(fk=>fk.StudentId);

        // techer 1 ----------------------> n message

        builder.Entity<Message>()
                .HasOne(m=>m.Teacher)
                .WithMany(t=>t.Messages)
                .HasForeignKey(fk=>fk.TeacherId);


        // onlineClass 1----------------------> n Question
         builder.Entity<Question>()
                .HasOne(q=>q.OnlineClass)
                .WithMany(oc=>oc.Questions)
                .HasForeignKey(fk=>fk.OnlineClassId);
        
        // student 1 ----------------> n question

        builder.Entity<Question>()
                .HasOne(q=>q.Student)
                .WithMany(s=>s.Questions)
                .HasForeignKey(fk=>fk.StudentId);

        // Question 1 ---------------------> n Answer
         builder.Entity<Answer>()
                .HasOne(a=>a.Question)
                .WithMany(oc=>oc.Answers)
                .HasForeignKey(fk=>fk.QuestionId);
        // 1 techer -------------------> n answer
        builder.Entity<Answer>()
                .HasOne(a=>a.Teacher)
                .WithMany(t=>t.Answers)
                .HasForeignKey(fk=>fk.TeacherId);
        // student 1 ----------------> n answer
        builder.Entity<Answer>()
                .HasOne(a=>a.Student)
                .WithMany(s=>s.Answers)
                .HasForeignKey(fk=>fk.StudentId);
    }
}