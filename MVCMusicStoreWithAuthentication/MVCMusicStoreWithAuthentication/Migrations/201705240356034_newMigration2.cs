namespace MVCMusicStoreWithAuthentication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newMigration2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Reviews", name: "Album_AlbumId", newName: "AlbumId");
            RenameIndex(table: "dbo.Reviews", name: "IX_Album_AlbumId", newName: "IX_AlbumId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Reviews", name: "IX_AlbumId", newName: "IX_Album_AlbumId");
            RenameColumn(table: "dbo.Reviews", name: "AlbumId", newName: "Album_AlbumId");
        }
    }
}
