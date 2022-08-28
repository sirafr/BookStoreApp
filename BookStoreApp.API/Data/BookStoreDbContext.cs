using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BookStoreApp.API.Data
{
    public partial class BookStoreDbContext : IdentityDbContext<ApiUser>
    {
        public BookStoreDbContext()
        {
        }

        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; } = null!;
        public virtual DbSet<Book> Books { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // This should be put when we use entity framework
            modelBuilder.Entity<Author>(entity =>
            {
                entity.Property(e => e.Bio).HasMaxLength(250);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasIndex(e => e.Isbn, "UQ__Books__447D36EAB970C5B3")
                    .IsUnique();

                entity.Property(e => e.Image).HasMaxLength(50);

                entity.Property(e => e.Isbn)
                    .HasMaxLength(50)
                    .HasColumnName("ISBN");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Summary).HasMaxLength(250);

                entity.Property(e => e.Title).HasMaxLength(50);

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.AuthorId)
                    .HasConstraintName("FK_Books_ToTable");
            });

            modelBuilder.Entity<IdentityRole>().HasData(
                    new IdentityRole
                    {
                        Name="User",
                        NormalizedName="USER",
                        Id = "c3fc13df-51c7-49a7-9797-30f04d4752a1"
                    },
                    new IdentityRole
                    {
                        Name="Administrator",
                        NormalizedName="ADMINISTRATOR",
                        Id= "9a44931f-cc87-4e09-96b9-bf5a5f48ca37"
                    }
                );

            var hasher = new PasswordHasher<ApiUser>();

            modelBuilder.Entity<ApiUser>().HasData(
                new ApiUser
                {
                    Id= "29db6215-88b5-4a75-8f92-88b7c3844abb",
                    Email="admin@bookstore.com",
                    NormalizedEmail="ADMIN@BOOKSTORE.COM",
                    UserName = "admin@bookstore.com",
                    NormalizedUserName = "ADMIN@BOOKSTORE.COM",
                    FirstName="System",
                    LastName="Admin",
                    PasswordHash = hasher.HashPassword(null, "P@ssword1") 
                },
                new ApiUser
                {
                    Id = "c9eb3649-94ab-4a0d-a21b-cc499b618032",
                    Email = "user@bookstore.com",
                    NormalizedEmail = "USER@BOOKSTORE.COM",
                    UserName = "user@bookstore.com",
                    NormalizedUserName = "USER@BOOKSTORE.COM",
                    FirstName = "System",
                    LastName = "User",
                    PasswordHash = hasher.HashPassword(null, "P@ssword1")
                }
            );

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(

                new IdentityUserRole<string>
                {
                    RoleId= "c3fc13df-51c7-49a7-9797-30f04d4752a1",
                    UserId = "c9eb3649-94ab-4a0d-a21b-cc499b618032",
                },
                new IdentityUserRole<string>
                {
                    RoleId = "9a44931f-cc87-4e09-96b9-bf5a5f48ca37",
                    UserId = "29db6215-88b5-4a75-8f92-88b7c3844abb"
                }
                
                );

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
