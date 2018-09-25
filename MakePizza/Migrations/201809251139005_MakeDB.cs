namespace MakePizza.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeDB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ingrediente_Pizza", "GuidPedido", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ingrediente_Pizza", "GuidPedido");
        }
    }
}
