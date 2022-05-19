using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Messages
{
    public partial class MessagesDB : DbContext
    {
        public MessagesDB()
            : base("name=MessagesDB")
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                .Property(e => e.First_name)
                .IsUnicode(false);

            modelBuilder.Entity<Author>()
                .Property(e => e.Last_name)
                .IsUnicode(false);

            modelBuilder.Entity<Author>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Author>()
                .Property(e => e.Added)
                .HasPrecision(0);

            modelBuilder.Entity<Author>()
                .HasMany(e => e.Posts)
                .WithRequired(e => e.Author)
                .HasForeignKey(e => e.Author_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Post>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Post>()
                .Property(e => e.Content)
                .IsUnicode(false);
        }
    }
}
