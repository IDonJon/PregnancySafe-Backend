using Microsoft.EntityFrameworkCore;
using PregnancySafe.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PregnancySafe.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        //public DbSet<Advice> Advices { get; set; }
        //public DbSet<Chat> Chats { get; set; }
        //public DbSet<MedicalAppointment> MedicalAppointments { get; set; }
        //public DbSet<MedicalExam> MedicalExams { get; set; }
        //public DbSet<Message> Messages { get; set; }
        public DbSet<Mother> Mothers { get; set; }
        public DbSet<Obstetrician> Obstetricians { get; set; }
        //public DbSet<PregnancyStage> PregnancyStages { get; set; }
        //public DbSet<Video> Videos { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Advice
            //builder.Entity<Advice>().ToTable("Advice");
            //builder.Entity<Advice>().HasKey(p => p.Id);
            //builder.Entity<Advice>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            //builder.Entity<Advice>().Property(p => p.Title).IsRequired().HasMaxLength(50);
            //builder.Entity<Advice>().Property(p => p.Text).IsRequired().HasMaxLength(250);
            //builder.Entity<Advice>().Property(p => p.PostDate).IsRequired().ValueGeneratedOnAdd();

            ////Chat
            //builder.Entity<Chat>().ToTable("Chat");
            //builder.Entity<Chat>().HasKey(p => p.Id);
            //builder.Entity<Chat>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            //builder.Entity<Chat>().HasMany(p => p.Messages)
            //    .WithOne(p => p.Chat).HasForeignKey(p => p.ChatId);

            ////MedicalAppointment
            //builder.Entity<MedicalAppointment>().ToTable("Medical_Appointment");
            //builder.Entity<MedicalAppointment>().HasKey(p => p.Id);
            //builder.Entity<MedicalAppointment>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            //builder.Entity<MedicalAppointment>().Property(p => p.Date).IsRequired().ValueGeneratedOnAdd();

            ////MedicalExam
            //builder.Entity<MedicalExam>().ToTable("Medical_Exam");
            //builder.Entity<MedicalExam>().HasKey(p => p.Id);
            //builder.Entity<MedicalExam>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            //builder.Entity<MedicalExam>().Property(p => p.ExamType).IsRequired().HasMaxLength(30);
            //builder.Entity<MedicalExam>().Property(p => p.Description).IsRequired();
            //builder.Entity<MedicalExam>().Property(p => p.Result).IsRequired();

            //builder.Entity<MedicalExam>().HasData(
            //    new MedicalExam
            //    {
            //        Id = 100,
            //        ExamType = "Examen Tipo 1",
            //        Description = "Es un examen de tipo 1",
            //        Result = "Sin Resultados"
            //    }
            //    );

            //Message
            //builder.Entity<Message>().ToTable("Message");
            //builder.Entity<Message>().HasKey(p => p.Id);
            //builder.Entity<Message>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            //builder.Entity<Message>().Property(p => p.SenderId).IsRequired().ValueGeneratedOnAdd();
            //builder.Entity<Message>().Property(p => p.Text).IsRequired().HasMaxLength(250);
            //builder.Entity<Message>().Property(p => p.Date).IsRequired().ValueGeneratedOnAdd();

            //Mother
            builder.Entity<Mother>().ToTable("Mother");
            builder.Entity<Mother>().HasKey(p => p.Id);
            builder.Entity<Mother>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Mother>().Property(p => p.FirstName).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Mother>().Property(p => p.LastName).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Mother>().Property(p => p.Email).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Mother>().Property(p => p.Age).IsRequired().ValueGeneratedOnAdd();
            //builder.Entity<Mother>().HasMany(p => p.Chats)
            //    .WithOne(p => p.Mother).HasForeignKey(p => p.MotherId);

            //builder.Entity<Mother>().HasMany(p => p.MedicalAppointments)
            //    .WithOne(p => p.Mother).HasForeignKey(p => p.MotherId);

            //builder.Entity<Mother>().HasMany(p => p.MedicalExams)
            //    .WithOne(p => p.Mother).HasForeignKey(p => p.MotherId);

            //Obstetrician
            builder.Entity<Obstetrician>().ToTable("Obstetrcian");
            builder.Entity<Obstetrician>().HasKey(p => p.Id);
            builder.Entity<Obstetrician>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Obstetrician>().Property(p => p.FirstName).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Obstetrician>().Property(p => p.LastName).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Obstetrician>().Property(p => p.Email).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Obstetrician>().Property(p => p.Age).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Obstetrician>().Property(p => p.Degree).IsRequired().ValueGeneratedOnAdd();
            //builder.Entity<Obstetrician>().HasMany(p => p.Advices)
            //    .WithOne(p => p.Obstetrician).HasForeignKey(p => p.ObstetricianId);

            //builder.Entity<Obstetrician>().HasMany(p => p.Chats)
            //    .WithOne(p => p.Obstetrician).HasForeignKey(p => p.ObstetricianId);

            //builder.Entity<Obstetrician>().HasMany(p => p.MedicalAppointments)
            //    .WithOne(p => p.Obstetrician).HasForeignKey(p => p.ObstetricianId);

            //builder.Entity<Obstetrician>().HasMany(p => p.MedicalExams)
            //    .WithOne(p => p.Obstetrician).HasForeignKey(p => p.ObstetricianId);

            //builder.Entity<Obstetrician>().HasMany(p => p.Videos)
            //    .WithOne(p => p.Obstetrician).HasForeignKey(p => p.ObstetricianId);


            ////PregnancyStage
            //builder.Entity<PregnancyStage>().ToTable("Pregnancy_Stage");
            //builder.Entity<PregnancyStage>().HasKey(p => p.Id);
            //builder.Entity<PregnancyStage>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            //builder.Entity<PregnancyStage>().Property(p => p.Range).IsRequired().ValueGeneratedOnAdd();
            //builder.Entity<PregnancyStage>().Property(p => p.Description).IsRequired().HasMaxLength(250);
            //builder.Entity<PregnancyStage>().HasMany(p => p.Mothers)
            //    .WithOne(p => p.PregnancyStage).HasForeignKey(p => p.PregnancyStageId);

            ////Video
            //builder.Entity<Video>().ToTable("Video");
            //builder.Entity<Video>().HasKey(p => p.Id);
            //builder.Entity<Video>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            //builder.Entity<Video>().Property(p => p.Url).IsRequired().ValueGeneratedOnAdd();
            //builder.Entity<Video>().Property(p => p.PostDate).IsRequired().ValueGeneratedOnAdd();
            //builder.Entity<Video>().Property(p => p.Title).IsRequired().HasMaxLength(50);

        }
    }
}
