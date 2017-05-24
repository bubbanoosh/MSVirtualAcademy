namespace MVCMusicStoreWithAuthentication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newMigration13 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Bands", "ArtistId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bands", "ArtistId", c => c.Int(nullable: false));
        }
    }
}
