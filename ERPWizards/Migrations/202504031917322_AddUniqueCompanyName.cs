namespace ERPWizards.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUniqueCompanyName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Companies", "CompanyName", c => c.String(maxLength: 100));
            CreateIndex("dbo.Companies", "CompanyName", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Companies", new[] { "CompanyName" });
            AlterColumn("dbo.Companies", "CompanyName", c => c.String());
        }
    }
}
