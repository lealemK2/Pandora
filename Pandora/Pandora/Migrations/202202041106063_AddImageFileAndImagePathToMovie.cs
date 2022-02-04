namespace Pandora.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageFileAndImagePathToMovie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "ImagePath", c => c.String());
            DropColumn("dbo.Movies", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "Image", c => c.String());
            DropColumn("dbo.Movies", "ImagePath");
        }
    }
}
