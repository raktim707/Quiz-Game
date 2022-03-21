using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace QuizApp.Models
{
    public partial class QuizAppContext : DbContext
    {
        public QuizAppContext()
        {
        }

        public QuizAppContext(DbContextOptions<QuizAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ButtonKey> ButtonKeys { get; set; } = null!;
        public virtual DbSet<Exam> Exams { get; set; } = null!;
        public virtual DbSet<ExamQuestion> ExamQuestions { get; set; } = null!;
        public virtual DbSet<ExamSubject> ExamSubjects { get; set; } = null!;
        public virtual DbSet<Option> Options { get; set; } = null!;
        public virtual DbSet<Question> Questions { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<Subject> Subjects { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=QuizApp;Integrated Security=False;Persist Security Info=False;User ID=QuizAppUser;Password=ezt7XpATfEMEvYzu");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ButtonKey>(entity =>
            {
                entity.ToTable("ButtonKey");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Key)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Exam>(entity =>
            {
                entity.ToTable("Exam");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.MasterName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ExamQuestion>(entity =>
            {
                entity.ToTable("ExamQuestion");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.ExamSubject)
                    .WithMany(p => p.ExamQuestions)
                    .HasForeignKey(d => d.ExamSubjectId)
                    .HasConstraintName("FK_ExamQuestion_ExamSubject");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.ExamQuestions)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("FK_ExamQuestion_Question");
            });

            modelBuilder.Entity<ExamSubject>(entity =>
            {
                entity.ToTable("ExamSubject");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Exam)
                    .WithMany(p => p.ExamSubjects)
                    .HasForeignKey(d => d.ExamId)
                    .HasConstraintName("FK_ExamSubject_Exam");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.ExamSubjects)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK_ExamSubject_Subject");
            });

            modelBuilder.Entity<Option>(entity =>
            {
                entity.ToTable("Option");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Text)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.HasOne(d => d.Questiont)
                    .WithMany(p => p.Options)
                    .HasForeignKey(d => d.QuestiontId)
                    .HasConstraintName("FK_Option_Question");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.ToTable("Question");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Text)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK_Question_Subject");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.Exam)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.ExamId)
                    .HasConstraintName("FK_Student_Exam");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.ToTable("Subject");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
