using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AgapeChurchMemberApplication.Models
{
    public class Event
    {
        public int EventId { get; set; }
        [Display(Name = "Event Name")]
        public string EventName { get; set; }
        [Display(Name = "Event Details")]
        public string EventDetails { get; set; }
        [DataType(DataType.Date),DisplayFormat(DataFormatString = @"{0:dd\/MM\/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Event Date")]
        public DateTime EventDate { get; set; }
    }
}