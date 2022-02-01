namespace Pandora.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'76086052-0532-4ff3-bb02-24f116f5ebde', N'guest@pandora.com', 0, N'AA9jnuyoaIed9E2ClB/0/kP/S9H7ybyOVYngFqGZywACRE25QgHEXPvNeLASYQTSiQ==', N'ec17e65f-b590-4297-a352-4f2cd0ce0231', NULL, 0, 0, NULL, 1, 0, N'guest@pandora.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'bcd7f9a8-a3f2-4875-9ca1-c1bc8ed4c25e', N'admin@pandora.com', 0, N'ACDsitTKXanzqax/6rCc1GdF9JpaBhSR2C7PgJJf4dG9+u9tSnblqld2th2TRseHxw==', N'f8f8c454-fac6-4b3d-888b-0157ac0c9805', NULL, 0, 0, NULL, 1, 0, N'admin@pandora.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'dfdf8c7e-d9b0-4782-8273-9f92aa4f9e3f', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'bcd7f9a8-a3f2-4875-9ca1-c1bc8ed4c25e', N'dfdf8c7e-d9b0-4782-8273-9f92aa4f9e3f')
");
        }
        
        public override void Down()
        {
        }
    }
}
