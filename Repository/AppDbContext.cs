using Repository.ApiModels;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AppDbContext : System.Data.Entity.DbContext
    {
        public AppDbContext() : base("name=remote")
        {
            Database.Log = e => Debug.WriteLine(e);
        }
        //ControlPanel
        public DbSet<Division> Divisions { get; set; }
        public DbSet<Faculty> Facultys { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Live> Lives { get; set; }
        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Notif> Notifs { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<PaymentDetail> PaymentDetails { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamDetail> ExamDetails { get; set; }
        public DbSet<Homework> Homeworks { get; set; }
        public DbSet<Result> Results { get; set; }


        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomUser> RoomUsers { get; set; }
        public DbSet<ChatStatue> ChatStatues { get; set; }
        public DbSet<Chat> Chats { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Division>().ToTable("Divisions");
            modelBuilder.Entity<Faculty>().ToTable("Facultys");
            modelBuilder.Entity<Level>().ToTable("Levels");
            modelBuilder.Entity<Live>().ToTable("Lives");
            modelBuilder.Entity<Lecture>().ToTable("Lectures");
            modelBuilder.Entity<Material>().ToTable("Materials");
            modelBuilder.Entity<Notif>().ToTable("Notifs");
            modelBuilder.Entity<Payment>().ToTable("Payments");
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<PaymentDetail>().ToTable("PaymentDetails");
            modelBuilder.Entity<News>().ToTable("News");
            modelBuilder.Entity<Exam>().ToTable("Exams");
            modelBuilder.Entity<ExamDetail>().ToTable("ExamDetails");
            modelBuilder.Entity<Homework>().ToTable("Homeworks");
            modelBuilder.Entity<Result>().ToTable("Results");


            modelBuilder.Entity<Room>().ToTable("Rooms");
            modelBuilder.Entity<RoomUser>().ToTable("RoomUsers");
            modelBuilder.Entity<ChatStatue>().ToTable("ChatStatues");
            modelBuilder.Entity<Chat>().ToTable("Chats");
        }
    }
}
