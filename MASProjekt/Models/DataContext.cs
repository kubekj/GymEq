using System;
using MASProjekt.Models;
using Microsoft.EntityFrameworkCore;

namespace MASProjekt.Data
{
	public class DataContext : DbContext
	{
		public DataContext() {}

		public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public virtual DbSet<Activity> Activities { get; set; }
        public virtual DbSet<Agreement> Agreements { get; set; }
        public virtual DbSet<Cleaning> Cleanings { get; set; }
        public virtual DbSet<ClubMember> ClubMembers { get; set; }
        public virtual DbSet<Guest> Guests { get; set; }
        public virtual DbSet<Gym> Gyms { get; set; }
        public virtual DbSet<GymArea> GymAreas { get; set; }
        public virtual DbSet<Maid> Maids { get; set; }
        public virtual DbSet<Owner> Owners { get; set; }
        public virtual DbSet<PersonalTraining> PersonalTrainings { get; set; }
        public virtual DbSet<Trainer> Trainers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
            .Entity<Person>()
            .Property(e => e.Gender)
            .HasConversion(
                v => v.ToString(),
                v => (Gender)Enum.Parse(typeof(Gender), v));

            modelBuilder
                .Entity<Agreement>().HasKey(e => new { e.IdGym, e.IdPerson }).HasName("Agreement_PK");

            modelBuilder
                .Entity<PersonalTraining>()
                .Property(e => e.TrainingType)
                .HasConversion(
                    v => v.ToString(),
                    v => (TrainingType)Enum.Parse(typeof(TrainingType), v));

            modelBuilder
                .Entity<Agreement>()
                .Property(e => e.AgreementType)
                .HasConversion(
                    v => v.ToString(),
                    v => (AgreementType)Enum.Parse(typeof(AgreementType), v));

            modelBuilder.Entity<Cleaning>()
                .Property(e => e.MaterialsUsed)
                .HasConversion(v => string.Join(',', v), v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));

            modelBuilder.Entity<GymArea>()
                .Property(e => e.Equipment)
                .HasConversion(v => string.Join(',', v), v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));

            modelBuilder.Entity<Trainer>().HasData(
               new Trainer
               {
                   ID = 1,
                   Name = "Jacek",
                   Surname = "Placek",
                   Email = "blabla@wp.pl",
                   Gender = Gender.Men,
                   YearsOfExperience = 2,
                   HoursOfWorkInCurrentMonth = 144
               }
            );

            modelBuilder.Entity<Activity>().HasData(
                new Activity
                {
                    ID = 1,
                    Title = "Zamba",
                    Description = "Tanczymy do rana",
                    Start = DateTime.UtcNow,
                    End = DateTime.UtcNow,
                    TrainerId = 1
                }
            );

            modelBuilder.Entity<Agreement>().HasData(
                new Agreement
                {
                    SignUpDate = DateTime.UtcNow,
                    ResignationDate = DateTime.UtcNow,
                    AgreementType = AgreementType.Client,
                    IdGym = 1,
                    IdPerson = 1
                }
            );

            modelBuilder.Entity<ClubMember>().HasData(
                new ClubMember
                {
                    ID = 2,
                    Name = "Andrzej",
                    Surname = "Kejra",
                    Email = "ee@wp.pl",
                    Gender = Gender.Men,
                    Birthday = DateTime.UtcNow,
                    UniqueNumber = new Random().Next(),
                    AmountToPay = 1000.00f,
                    AmountPayed = 120044.00f
                }
            );

            modelBuilder.Entity<Guest>().HasData(
                new Guest
                {
                    ID = 3,
                    Name = "Klocu",
                    Surname = "12",
                    Email = "kl@wp.pl",
                    Gender = Gender.Men,
                }
            );

            modelBuilder.Entity<Gym>().HasData(
                new Gym
                {
                    ID = 1,
                    Adress = "Szamocka 51"
                }
            );

            modelBuilder.Entity<Maid>().HasData(
                new Maid
                {
                    ID = 4,
                    Name = "Bozena",
                    Surname = "Wa",
                    Email = "bw@wp.pl",
                    Gender = Gender.Woman,
                }
            );

            modelBuilder.Entity<Owner>().HasData(
                new Owner
                {
                    ID = 5,
                    Name = "Szeryf",
                    Surname = "Szefoski",
                    Email = "szef@wp.pl",
                    Gender = Gender.Unknown,
                }
            );

            modelBuilder.Entity<PersonalTraining>().HasData(
                new PersonalTraining
                {
                    ID = 1,
                    TrainingType = TrainingType.Cardio,
                    Duration = 20,
                    Opinion = "Super ekstra",
                    ClubMemberId = 2,
                    TrainerId = 1
                }
            );
        }
    }
}

