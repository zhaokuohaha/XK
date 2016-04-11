using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Linq;
using System.Web;

namespace XK.Models
{
    public class xk_quote
    {
        [Key]
        public int q_id { get; set; }
        public string q_user { get; set; }
        public string q_content { get; set; }
    }
}