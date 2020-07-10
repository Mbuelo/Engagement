using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AgapeChurchMemberApplication.Models
{
    public class IndividualGroup
    {
        [Key]
        [Column(Order=1)]
        public int IndividualId { get; set; }
        [Key]
        [Column(Order = 2)]
        public int GroupId { get; set; } 

        public virtual Individual Individual { get; set; }
        public virtual Group Group { get; set; }
    }
}