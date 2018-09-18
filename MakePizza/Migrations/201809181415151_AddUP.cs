namespace MakePizza.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUP : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Ingrediente_Pizza", name: "ingrediente_IdIngrediente", newName: "ingredientePizza_IdIngrediente");
            RenameIndex(table: "dbo.Ingrediente_Pizza", name: "IX_ingrediente_IdIngrediente", newName: "IX_ingredientePizza_IdIngrediente");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Ingrediente_Pizza", name: "IX_ingredientePizza_IdIngrediente", newName: "IX_ingrediente_IdIngrediente");
            RenameColumn(table: "dbo.Ingrediente_Pizza", name: "ingredientePizza_IdIngrediente", newName: "ingrediente_IdIngrediente");
        }
    }
}
