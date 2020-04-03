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
        [MinLength(20)]
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
            String sqlQuery = "select * from Article " +
                                "where ArtStatus='Active' " +
                                "Order by ArtPostTime desc";
            var list = context.Database.SqlQuery<Article>(sqlQuery).ToList();
            return list;
        }
        public List<Article> getListManagerArticle()
        {
            String sqlQuery = "select * from Article " +
                                "Order by ArtPostTime desc";
            var list = context.Database.SqlQuery<Article>(sqlQuery).ToList();
            return list;
        }
        public Article getDetailArticle(int? ArtId)
        {
            String sqlQuery = "select * from Article where ArtID={0}";
            var article = context.Database.SqlQuery<Article>(sqlQuery, ArtId).FirstOrDefault();
            return article;
        }
        public bool Delete(int ArtId)
        {
            String sqlQuery = "Update Article set ArtStatus='Deleted' where ArtID={0}";
            var check = context.Database.ExecuteSqlCommand(sqlQuery, ArtId);
            return true;
        }
        public bool Approve(int ArtId)
        {
            String sqlQuery = "Update Article set ArtStatus='Active' where ArtID={0}";
            var check = context.Database.ExecuteSqlCommand(sqlQuery, ArtId);
            return true;
        }
        public List<Article> searchActiveArticle(string searchVal)
        {
            searchVal = "%" + searchVal + "%";
            String sqlQuery = "select * from Article " +
                                "where ArtStatus='Active' and ArtTittle like {0} " +
                                "Order by ArtPostTime desc";

            var list = context.Database.SqlQuery<Article>(sqlQuery, searchVal).ToList();
            return list;
        }
        public List<Article> searchManagerArticle(string searchVal)
        {
            searchVal = "%" + searchVal + "%";
            String sqlQuery = "select * from Article " +
                                "where  ArtTittle like {0} " +
                                "Order by ArtPostTime desc";

            var list = context.Database.SqlQuery<Article>(sqlQuery, searchVal).ToList();
            return list;
        }

        public List<Article> getListArticleOfUser(string username)
        {
            String sqlQuery = "select * from Article " +
                                "where ArtUsername={0} " +
                                "Order by ArtPostTime desc";
            var list = context.Database.SqlQuery<Article>(sqlQuery, username).ToList();
            return list;
        }

    }
}
