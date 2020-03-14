namespace WebApplication1.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CommentDBContext : DbContext
    {
        public CommentDBContext()
            : base("name=Comment")
        {
        }

        public virtual DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>()
                .Property(e => e.CommContent)
                .IsUnicode(false);

            modelBuilder.Entity<Comment>()
                .Property(e => e.Username)
                .IsUnicode(false);
        }
    }
}
