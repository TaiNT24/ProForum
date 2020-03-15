namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    [Table("Comment")]
    public partial class Comment
    {
        [Key]
        public int CommID { get; set; }

        [Required]
        [StringLength(300)]
        public string CommContent { get; set; }

        public DateTime CommPostTime { get; set; }

        [Required]
        [StringLength(20)]
        public string Username { get; set; }

        public int ArtID { get; set; }
    }

    public class CommentList { 
     CommentDBContext context = null;

    public CommentList()
    {
        context = new CommentDBContext();
    }

    public List<Comment> getListComment(int? idArt)
    {
           
        String sqlQuery = "select * from Comment where ArtID={0} order by CommPostTime DESC";

            var list = context.Database.SqlQuery<Comment>(sqlQuery,idArt).ToList();
        return list;
    }



}
    }
