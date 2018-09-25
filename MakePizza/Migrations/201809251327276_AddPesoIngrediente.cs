namespace MakePizza.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPesoIngrediente : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ingrediente", "PesoIngrediente", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ingrediente", "PesoIngrediente");
        }
    }
}
