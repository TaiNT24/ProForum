namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.SqlClient;
    using System.Linq;

    [Table("Article")]
    public partial class Article
    {
        [Key]
        public int ArtID { get; set; }

        [Required]
        [StringLength(300)]
        public string ArtTittle { get; set; }

        [Required]
        [StringLength(3000)]
        public string ArtContent { get; set; }

        public DateTime ArtPostTime { get; set; }

        [Required]
        [StringLength(50)]
        public string ArtAuthor { get; set; }

        [Required]
        [StringLength(20)]
        public string ArtUsername { get; set; }

        [Required]
        [StringLength(30)]
        public string ArtStatus { get; set; }

    }

    public class ArticleList
    {
        ArticleDBContext context = null;

        public ArticleList()
        {
            context = new ArticleDBContext();
        }

        public List<Article> getListActiveArticle()
        {
            String sqlQuery = "select * from Article where ArtStatus='Active'";
            var list = context.Database.SqlQuery<Article>(sqlQuery).ToList();
            return list;
        }
    }
}
