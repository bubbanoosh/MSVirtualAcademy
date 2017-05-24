namespace MVCMusicStoreWithAuthentication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        AlbumId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        BandId = c.Int(nullable: false),
                        ReviewId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AlbumId)
                .ForeignKey("dbo.Bands", t => t.BandId, cascadeDelete: true)
                .Index(t => t.BandId);
            
            CreateTable(
                "dbo.Bands",
                c => new
                    {
                        BandId = c.Int(nullable: false, identity: true),
                        BandName = c.String(),
                        Website = c.String(nullable: false),
                        ArtistId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BandId);
            
            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        ArtistId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(nullable: false),
                        Band_BandId = c.Int(),
                    })
                .PrimaryKey(t => t.ArtistId)
                .ForeignKey("dbo.Bands", t => t.Band_BandId)
                .Index(t => t.Band_BandId);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        ReviewId = c.Int(nullable: false, identity: true),
                        Comment = c.String(),
                        AlbumId = c.Int(nullable: false),
                        ReviewerId = c.String(),
                        Reviewer_ReviewerId = c.Int(),
                    })
                .PrimaryKey(t => t.ReviewId)
                .ForeignKey("dbo.Albums", t => t.AlbumId, cascadeDelete: true)
                .ForeignKey("dbo.Reviewers", t => t.Reviewer_ReviewerId)
                .Index(t => t.AlbumId)
                .Index(t => t.Reviewer_ReviewerId);
            
            CreateTable(
                "dbo.Reviewers",
                c => new
                    {
                        ReviewerId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ReviewerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "Reviewer_ReviewerId", "dbo.Reviewers");
            DropForeignKey("dbo.Reviews", "AlbumId", "dbo.Albums");
            DropForeignKey("dbo.Albums", "BandId", "dbo.Bands");
            DropForeignKey("dbo.Artists", "Band_BandId", "dbo.Bands");
            DropIndex("dbo.Reviews", new[] { "Reviewer_ReviewerId" });
            DropIndex("dbo.Reviews", new[] { "AlbumId" });
            DropIndex("dbo.Artists", new[] { "Band_BandId" });
            DropIndex("dbo.Albums", new[] { "BandId" });
            DropTable("dbo.Reviewers");
            DropTable("dbo.Reviews");
            DropTable("dbo.Artists");
            DropTable("dbo.Bands");
            DropTable("dbo.Albums");
        }
    }
}
