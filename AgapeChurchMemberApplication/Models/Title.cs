using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AgapeChurchMemberApplication.Models
{
    public class Title
    {
        public int TitleId { get; set; }
        [Display(Name = "Title")]
        public string _Title { get; set; }
    }
}