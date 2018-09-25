using MakePizza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakePizza.DAO
{
	public class Pizza_PedidoDAO
	{
		#region Contexto
		private static Contexto contexto = SingletonContexto.GetInstance();
		#endregion


		#region CadastrarPizza_Pedido(Pizza)
		public static bool CadastrarPizza_Pedido(Pizza_Pedido pizza_Pedido)
		{
			try
			{
				contexto.Pizza_Pedidos.Add(pizza_Pedido) ;
				contexto.SaveChanges();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public static List<Pizza_Pedido> RetornarPizza_PedidoPorGuid(string sessaoPedidoAtual)
		{
			return contexto.Pizza_Pedidos.Where(_ => _.GuidPedido.Equals(sessaoPedidoAtual)).ToList();
		}

		//public static bool AtualizarPizza_Pedido( List<Pizza_Pedido> lstPizzasConfirmadas, List<Pizza_Pedido> lstPizza_Pedidos)
		//{
		//	try
		//	{
		//		//Apaga lista de pizza antiga
		//		foreach (var pizza_pedido in lstPizza_Pedidos)
		//		{
		//			contexto.Pizza_Pedidos.Remove(pizza_pedido);
		//			contexto.SaveChanges();
		//		}

		//		//Cria uma nova lista de pizza_pedido
		//		foreach (var pizza_pedido in lstPizzasConfirmadas)
		//		{
		//			contexto.Pizza_Pedidos.Add(pizza_pedido);
		//			contexto.SaveChanges();
		//		}
		//		return true;
		//	}
		//	catch (Exception)
		//	{
		//		return false;

		//	}
		//}
		#endregion

	}
}