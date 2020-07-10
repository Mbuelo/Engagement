namespace AgapeChurchMemberApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fixing : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        EventName = c.String(),
                        EventDetails = c.String(),
                        EventDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EventId);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        GroupId = c.Int(nullable: false, identity: true),
                        GroupName = c.String(),
                        GroupDetails = c.String(),
                    })
                .PrimaryKey(t => t.GroupId);
            
            CreateTable(
                "dbo.IndividualGroups",
                c => new
                    {
                        IndividualId = c.Int(nullable: false),
                        GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.IndividualId, t.GroupId })
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.Individuals", t => t.IndividualId, cascadeDelete: true)
                .Index(t => t.IndividualId)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.Individuals",
                c => new
                    {
                        IndividualId = c.Int(nullable: false, identity: true),
                        IndividualEntryDate = c.String(),
                        IndividualTitle = c.String(),
                        IndividualName = c.String(),
                        IndividualLastName = c.String(),
                        IndividualIDNumber = c.Long(nullable: false),
                        IndividualAddress = c.String(),
                        IndividualNumber = c.String(),
                        IndividualEmail = c.String(),
                        IndividualLanguage = c.String(),
                        IndividualBaptismalDate = c.DateTime(nullable: false),
                        IndividualStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IndividualId);
            
            CreateTable(
                "dbo.Titles",
                c => new
                    {
                        TitleId = c.Int(nullable: false, identity: true),
                        _Title = c.String(),
                    })
                .PrimaryKey(t => t.TitleId);
            
            CreateTable(
                "dbo.Visitors",
                c => new
                    {
                        VisitorId = c.Int(nullable: false, identity: true),
                        VisitorEntryDate = c.String(),
                        VisitorTitle = c.String(),
                        VisitorName = c.String(),
                        VisitorLastName = c.String(),
                        VisitorIDNumber = c.Long(nullable: false),
                        VisitorAddress = c.String(),
                        VisitorNumber = c.String(),
                        VisitorEmail = c.String(),
                        VisitorLanguage = c.String(),
                        VisitorStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.VisitorId);
            
            CreateTable(
                "dbo.VisitorEvents",
                c => new
                    {
                        VisitorId = c.Int(nullable: false),
                        EventId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.VisitorId, t.EventId })
                .ForeignKey("dbo.Events", t => t.EventId, cascadeDelete: true)
                .ForeignKey("dbo.Visitors", t => t.VisitorId, cascadeDelete: true)
                .Index(t => t.VisitorId)
                .Index(t => t.EventId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VisitorEvents", "VisitorId", "dbo.Visitors");
            DropForeignKey("dbo.VisitorEvents", "EventId", "dbo.Events");
            DropForeignKey("dbo.IndividualGroups", "IndividualId", "dbo.Individuals");
            DropForeignKey("dbo.IndividualGroups", "GroupId", "dbo.Groups");
            DropIndex("dbo.VisitorEvents", new[] { "EventId" });
            DropIndex("dbo.VisitorEvents", new[] { "VisitorId" });
            DropIndex("dbo.IndividualGroups", new[] { "GroupId" });
            DropIndex("dbo.IndividualGroups", new[] { "IndividualId" });
            DropTable("dbo.VisitorEvents");
            DropTable("dbo.Visitors");
            DropTable("dbo.Titles");
            DropTable("dbo.Individuals");
            DropTable("dbo.IndividualGroups");
            DropTable("dbo.Groups");
            DropTable("dbo.Events");
        }
    }
}
