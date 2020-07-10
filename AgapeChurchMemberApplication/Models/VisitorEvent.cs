using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AgapeChurchMemberApplication.Models
{
    public class VisitorEvent
    {
        [Key]
        [Column(Order = 1)]
        public int VisitorId { get; set; }
        [Key]
        [Column(Order = 2)]
        public int EventId { get; set; }

        public virtual Visitor Visitor { get; set; }
        public virtual Event Event { get; set; }
    }
}