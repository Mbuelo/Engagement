using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AgapeChurchMemberApplication.Models
{
    public class AgapeDBContext:DbContext 
    {
        public DbSet <Individual> Individual { get; set; }
        public DbSet <Title> Title { get; set; }
        public DbSet <Group> Group { get; set; }
        public DbSet <IndividualGroup> IndividualGroup { get; set; }
        public DbSet <Visitor> Visitor { get; set; }
        public DbSet <Event> Event { get; set; }
        public DbSet <VisitorEvent> VisitorEvent { get; set; }
    }
}