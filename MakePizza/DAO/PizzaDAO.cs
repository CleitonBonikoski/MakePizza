using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MakePizza.Models;
using MakePizza.Utils;

namespace MakePizza.DAO
{
	public class PizzaDAO
	{
		#region Contexto
		private static Contexto contexto = SingletonContexto.GetInstance();
		#endregion

		#region CadastrarPizza(Pizza)
		public static bool CadastrarPizza(Pizza pizza)
		{
			try
			{
				pizza.DataPizza = DateTime.Now;
				contexto.Pizzas.Add(pizza);
				contexto.SaveChanges();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}
		#endregion
		
		public static List<Pizza> RetornarPizzaPedido()
		{
			string GuidPedidoAtual = Sessao.CriarSessaoPedido();
			return contexto.Pizzas.Where(_ => _.GuidPedido.Equals(GuidPedidoAtual)).ToList();
		}
	}
}