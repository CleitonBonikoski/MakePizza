namespace MakePizza.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriateDB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pedido", "GuidPedido", c => c.String());
            AddColumn("dbo.Pizza_Pedido", "GuidPedido", c => c.String());
            AddColumn("dbo.Pizza", "GuidPizza", c => c.String());
            AddColumn("dbo.Pizza", "GuidPedido", c => c.String());
            AddColumn("dbo.Ingrediente_Pizza", "GuidPizza", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ingrediente_Pizza", "GuidPizza");
            DropColumn("dbo.Pizza", "GuidPedido");
            DropColumn("dbo.Pizza", "GuidPizza");
            DropColumn("dbo.Pizza_Pedido", "GuidPedido");
            DropColumn("dbo.Pedido", "GuidPedido");
        }
    }
}
