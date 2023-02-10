namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class yenisutun : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Abouts", "AboutContent3", c => c.String(maxLength: 500));
            AddColumn("dbo.Abouts", "AboutImage3", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Abouts", "AboutImage3");
            DropColumn("dbo.Abouts", "AboutContent3");
        }
    }
}
