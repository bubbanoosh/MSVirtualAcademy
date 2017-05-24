namespace MVCMusicStoreWithAuthentication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newMigration11 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Albums", "Title", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Albums", "Title", c => c.String());
        }
    }
}
