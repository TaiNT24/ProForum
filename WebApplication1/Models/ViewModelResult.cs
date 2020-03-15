using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace WebApplication1.Models
{
    public class ViewModelResult
    {
        public Article articleDetail { get; set; }
        public List<Comment> listComment { get; set; }
    }
}