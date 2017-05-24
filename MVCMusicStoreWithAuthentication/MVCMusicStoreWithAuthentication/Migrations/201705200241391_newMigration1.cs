namespace MVCMusicStoreWithAuthentication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newMigration1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Albums", "ReviewId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Albums", "ReviewId", c => c.Int(nullable: false));
        }
    }
}
