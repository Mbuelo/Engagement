using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AgapeChurchMemberApplication.Models
{
    public class Visitor
    {
        [Key]
        [Column(Order = 0)]
        public int VisitorId { get; set; }
        [Column(Order = 1)]
        [Display(Name = "Entry Date")]
        public string VisitorEntryDate { get; set; }
        [Column(Order = 2)]
        [Display(Name = "Title")]
        public string VisitorTitle { get; set; }
        [Column(Order = 3)]
        [Display(Name = "Name(s)")]
        public string VisitorName { get; set; }
        [Column(Order = 4)]
        [Display(Name = "Surname")]
        public string VisitorLastName { get; set; }
        [Column(Order = 5)]
        [Display(Name = "ID Number")]
        public long VisitorIDNumber { get; set; }
        [Column(Order = 6)]
        [Display(Name = "Gender")]
        public char VisitorGender { get; set; }
        [Column(Order = 7)]
        [Display(Name = "Residential Address")]
        public string VisitorAddress { get; set; }
        [Column(Order = 8)]
        [Display(Name = "Contact Number")]
        public string VisitorNumber { get; set; }
        [Column(Order = 9)]
        [Display(Name = "Email Address")]
        public string VisitorEmail { get; set; }
        [Column(Order = 10)]
        [Display(Name = "Language")]
        public string VisitorLanguage { get; set; }
        [Column(Order = 11)]
        [Display(Name = "Status")]
        public bool VisitorStatus { get; set; }
    }
}