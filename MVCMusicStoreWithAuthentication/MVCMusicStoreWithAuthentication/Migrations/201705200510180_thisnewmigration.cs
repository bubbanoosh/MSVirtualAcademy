namespace MVCMusicStoreWithAuthentication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class thisnewmigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reviews", "Reviewer_ReviewerId", "dbo.Reviewers");
            DropIndex("dbo.Reviews", new[] { "Reviewer_ReviewerId" });
            RenameColumn(table: "dbo.Albums", name: "BandId", newName: "Band_BandId");
            RenameColumn(table: "dbo.Reviews", name: "AlbumId", newName: "Album_AlbumId");
            RenameIndex(table: "dbo.Albums", name: "IX_BandId", newName: "IX_Band_BandId");
            RenameIndex(table: "dbo.Reviews", name: "IX_AlbumId", newName: "IX_Album_AlbumId");
            AlterColumn("dbo.Reviews", "Reviewer_ReviewerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Reviews", "Reviewer_ReviewerId");
            AddForeignKey("dbo.Reviews", "Reviewer_ReviewerId", "dbo.Reviewers", "ReviewerId", cascadeDelete: true);
            DropColumn("dbo.Reviews", "ReviewerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reviews", "ReviewerId", c => c.String());
            DropForeignKey("dbo.Reviews", "Reviewer_ReviewerId", "dbo.Reviewers");
            DropIndex("dbo.Reviews", new[] { "Reviewer_ReviewerId" });
            AlterColumn("dbo.Reviews", "Reviewer_ReviewerId", c => c.Int());
            RenameIndex(table: "dbo.Reviews", name: "IX_Album_AlbumId", newName: "IX_AlbumId");
            RenameIndex(table: "dbo.Albums", name: "IX_Band_BandId", newName: "IX_BandId");
            RenameColumn(table: "dbo.Reviews", name: "Album_AlbumId", newName: "AlbumId");
            RenameColumn(table: "dbo.Albums", name: "Band_BandId", newName: "BandId");
            CreateIndex("dbo.Reviews", "Reviewer_ReviewerId");
            AddForeignKey("dbo.Reviews", "Reviewer_ReviewerId", "dbo.Reviewers", "ReviewerId");
        }
    }
}
