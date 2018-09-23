namespace MakePizza.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeNamePizza : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pizza", "NomePizza", c => c.String());
            AlterColumn("dbo.Pizza", "TamanhoPizza", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pizza", "TamanhoPizza", c => c.Int(nullable: false));
            DropColumn("dbo.Pizza", "NomePizza");
        }
    }
}
