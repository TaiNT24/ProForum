namespace WebApplication1.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ArticleDBContext : DbContext
    {
        public ArticleDBContext()
            : base("name=ArticleDBContext")
        {
        }

        public virtual DbSet<Article> Articles { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Article>()
                .Property(e => e.ArtTittle)
                .IsUnicode(false);

            modelBuilder.Entity<Article>()
                .Property(e => e.ArtContent)
                .IsUnicode(false);

            modelBuilder.Entity<Article>()
                .Property(e => e.ArtAuthor)
                .IsUnicode(false);

            modelBuilder.Entity<Article>()
                .Property(e => e.ArtUsername)
                .IsUnicode(false);

            modelBuilder.Entity<Article>()
                .Property(e => e.ArtStatus)
                .IsUnicode(false);
        }
    }
}
