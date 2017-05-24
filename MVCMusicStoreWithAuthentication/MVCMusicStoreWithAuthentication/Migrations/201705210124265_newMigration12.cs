namespace MVCMusicStoreWithAuthentication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newMigration12 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Albums", name: "Band_BandId", newName: "BandId");
            RenameIndex(table: "dbo.Albums", name: "IX_Band_BandId", newName: "IX_BandId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Albums", name: "IX_BandId", newName: "IX_Band_BandId");
            RenameColumn(table: "dbo.Albums", name: "BandId", newName: "Band_BandId");
        }
    }
}
