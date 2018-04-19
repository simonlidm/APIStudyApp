using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApiCore.Models
{
    public partial class APIStudyAppDatabaseContext : DbContext
    {
        public virtual DbSet<Animal> Animal { get; set; }
        public virtual DbSet<AnimalDetail> AnimalDetail { get; set; }
        public virtual DbSet<AnimalText> AnimalText { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Detail> Detail { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<ItemsSkill> ItemsSkill { get; set; }
        public virtual DbSet<ItemTags> ItemTags { get; set; }
        public virtual DbSet<Keys> Keys { get; set; }
        public virtual DbSet<LoremText> LoremText { get; set; }
        public virtual DbSet<LoremTextComma> LoremTextComma { get; set; }
        public virtual DbSet<Office> Office { get; set; }
        public virtual DbSet<Skill> Skill { get; set; }
        public virtual DbSet<Tags> Tags { get; set; }
        public virtual DbSet<WorkExperience> WorkExperience { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=APIStudyAppDatabase;Persist Security Info=True;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>(entity =>
            {
                entity.Property(e => e.AnimalId).ValueGeneratedNever();
            });

            modelBuilder.Entity<AnimalDetail>(entity =>
            {
                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.Name).HasMaxLength(15);

                entity.Property(e => e.Url).HasMaxLength(50);

                entity.HasOne(d => d.Animal)
                    .WithMany(p => p.AnimalDetail)
                    .HasForeignKey(d => d.AnimalId)
                    .HasConstraintName("FK_AnimalDetail_Animal");
            });

            modelBuilder.Entity<AnimalText>(entity =>
            {
                entity.HasKey(e => e.AnimalId);

                entity.Property(e => e.AnimalDetails).HasColumnType("text");

                entity.Property(e => e.AnimalName).HasMaxLength(50);

                entity.Property(e => e.LoremText)
                    .HasColumnType("text")
                    .HasDefaultValueSql("('Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam sed urna eget metus viverra sollicitudin. Praesent mollis posuere commodo. Vestibulum vel nibh pharetra, malesuada arcu euismod, tempor nulla. Nunc lacinia quis arcu et aliquam. Interdum et malesuada fames ac ante ipsum primis in faucibus. Mauris tempor accumsan dignissim. Sed dapibus dolor in consequat iaculis. Integer elementum, nulla quis dapibus pharetra, neque velit aliquet lacus, non luctus lacus diam eget elit. Ut finibus, purus et volutpat accumsan, quam sem commodo elit, in commodo est nisi at turpis. In scelerisque purus eget dui efficitur, at consectetur enim pellentesque. In sit amet gravida.')");

                entity.Property(e => e.Url).HasColumnType("text");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Website).HasMaxLength(50);
            });

            modelBuilder.Entity<Detail>(entity =>
            {
                entity.Property(e => e.Author)
                    .HasColumnName("author")
                    .HasMaxLength(50);

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.Text)
                    .HasColumnName("text")
                    .HasColumnType("text");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Department).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<ItemsSkill>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.ItemsSkill)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_ItemsSkill_Employee");

                entity.HasOne(d => d.Skills)
                    .WithMany(p => p.ItemsSkill)
                    .HasForeignKey(d => d.SkillsId)
                    .HasConstraintName("FK_ItemsSkill_Skill");
            });

            modelBuilder.Entity<ItemTags>(entity =>
            {
                entity.HasKey(e => e.ItemTag);

                entity.HasOne(d => d.Detail)
                    .WithMany(p => p.ItemTags)
                    .HasForeignKey(d => d.DetailId)
                    .HasConstraintName("FK_ItemTags_Detail");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.ItemTags)
                    .HasForeignKey(d => d.TagId)
                    .HasConstraintName("FK_ItemTags_Tags");
            });

            modelBuilder.Entity<Keys>(entity =>
            {
                entity.HasKey(e => e.ApikeyId);

                entity.Property(e => e.ApikeyId)
                    .HasColumnName("APIKeyId")
                    .ValueGeneratedNever();

                entity.Property(e => e.ApikeyHash)
                    .HasColumnName("APIKeyHash")
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LoremText>(entity =>
            {
                entity.HasKey(e => e.NumberOfWords);

                entity.Property(e => e.NumberOfWords)
                    .HasColumnName("numberOfWords")
                    .ValueGeneratedNever();

                entity.Property(e => e.Lorem)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LoremTextComma>(entity =>
            {
                entity.HasKey(e => e.NumberOfWords);

                entity.Property(e => e.NumberOfWords)
                    .HasColumnName("numberOfWords")
                    .ValueGeneratedNever();

                entity.Property(e => e.LoremComma)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Office>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Office)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_Office_Employee");
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Title).HasMaxLength(50);
            });

            modelBuilder.Entity<Tags>(entity =>
            {
                entity.HasKey(e => e.TagId);

                entity.Property(e => e.TagId).HasColumnName("tagId");

                entity.Property(e => e.TagName).HasMaxLength(50);
            });

            modelBuilder.Entity<WorkExperience>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Title).HasMaxLength(50);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.WorkExperience)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_WorkExperience_Employee");
            });
        }
    }
}
