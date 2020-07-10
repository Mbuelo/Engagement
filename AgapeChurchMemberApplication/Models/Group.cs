using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AgapeChurchMemberApplication.Models
{
    public class Group
    {
        public int GroupId { get; set; }
        [Display(Name = "Group Name")]
        public string GroupName { get; set; }
        [Display(Name = "Group Details")]
        public string GroupDetails { get; set; }
        
        public virtual ICollection<IndividualGroup> IndividualGroups { get; set; }
    }

}