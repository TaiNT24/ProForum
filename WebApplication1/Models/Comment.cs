namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

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

    public class CommentList
    {

    }
}
