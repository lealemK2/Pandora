namespace Pandora.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageClass1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                 "dbo.Images",
                 c => new
                 {
                     Id = c.Int(nullable: false, identity: true),
                     file = c.String(),
                 })
                 .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
        }
    }
}
