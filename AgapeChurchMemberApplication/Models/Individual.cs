using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AgapeChurchMemberApplication.Models
{
    public class Individual
    {
        [Key]
        [Column(Order = 0)]
        public int IndividualId { get; set; }
        [Column(Order = 1)]
        [Display(Name = "Entry Date")]
        public string IndividualEntryDate { get; set; }
        [Column(Order = 2)]
        [Display(Name = "Title")]
        public string IndividualTitle { get; set; }
        [Column(Order = 3)]
        [Display(Name = "Name(s)")]
        public string IndividualName { get; set; }
        [Column(Order = 4)]
        [Display(Name = "Surname")]
        public string IndividualLastName { get; set; }
        [Column(Order = 5)]
        [Display(Name = "ID Number")]
        public long IndividualIDNumber { get; set; }
        [Column(Order = 6)]
        [Display(Name = "Gender")]
        public char IndividualGender { get; set; }
        [Column(Order = 7)]
        [Display(Name = "Residential Address")]
        public string IndividualAddress { get; set; }
        [Column(Order = 8)]
        [Display(Name = "Contact Number")]
        public string IndividualNumber { get; set; }
        [Column(Order = 9)]
        [Display(Name = "Email Address")]
        public string IndividualEmail { get; set; }
        [Column(Order = 10)]
        [Display(Name = "Language")]
        public string IndividualLanguage { get; set; }
        [Column(Order = 11)]
        [DataType(DataType.Date)]
        [Display(Name = "Baptismal Date")]
        public DateTime IndividualBaptismalDate { get; set; }
        [Column(Order = 12)]
        [Display(Name = "Status")]
        public bool IndividualStatus { get; set; }


        public virtual ICollection<IndividualGroup> IndividualGroups { get; set; }

    }
}