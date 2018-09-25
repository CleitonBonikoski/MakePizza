using MakePizza.DAO;
using MakePizza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakePizza.Utils
{
	public class Sessao
	{
		private static Contexto contexto = SingletonContexto.GetInstance();

		#region Session
		private static string CLIENTE_SESSION = "IdCliente";

		private static string INGREDIENTE_PIZZA_SESSION = "GuidPizza";

		private static string PIZZA_PEDIDO_SESSION = "GuidPedido";
		#endregion

		#region  CriarSessaoCliente()
		public static string CriarSessaoCliente()
		{
			if (HttpContext.Current.Session[CLIENTE_SESSION] == null)
			{
				Guid guid = Guid.NewGuid();
				HttpContext.Current.Session[CLIENTE_SESSION] = guid;
			}
			return HttpContext.Current.Session[CLIENTE_SESSION].ToString();
		}
		#endregion

		#region  CriarSessaoPizza()
		public static string CriarSessaoPizza()
		{
			if (HttpContext.Current.Session[INGREDIENTE_PIZZA_SESSION] == null)
			{
				Guid guid = Guid.NewGuid();
				HttpContext.Current.Session[INGREDIENTE_PIZZA_SESSION] = guid;
			}
			return HttpContext.Current.Session[INGREDIENTE_PIZZA_SESSION].ToString();
		}
		#endregion

		#region  CriarSessaoPedido()
		public static string CriarSessaoPedido()
		{
			if (HttpContext.Current.Session[PIZZA_PEDIDO_SESSION] == null)
			{
				Guid guid = Guid.NewGuid();
				HttpContext.Current.Session[PIZZA_PEDIDO_SESSION] = guid;
			}
			return HttpContext.Current.Session[PIZZA_PEDIDO_SESSION].ToString();
		}
		#endregion

		#region KillTodasAsSessoes()
		public static bool KillTodasAsSessoes()
		{
			try
			{				
				HttpContext.Current.Session[CLIENTE_SESSION] = null;
				HttpContext.Current.Session[INGREDIENTE_PIZZA_SESSION] = null;
				HttpContext.Current.Session[PIZZA_PEDIDO_SESSION] = null;

                return true;
			}
			catch (Exception)
			{
				return false;
			}
		}
		#endregion

		#region ValidarSessaoCliente()
		public static string ValidarSessaoCliente()
		{
			if (HttpContext.Current.Session[CLIENTE_SESSION] == null)
				return null;

			return HttpContext.Current.Session[CLIENTE_SESSION].ToString();
		}
		#endregion

		#region ValidarSessaoPizza()
		public static string ValidarSessaoPizza()
		{
			if (HttpContext.Current.Session[INGREDIENTE_PIZZA_SESSION] == null)
				return null;

			return HttpContext.Current.Session[INGREDIENTE_PIZZA_SESSION].ToString();
		}
		#endregion

		#region ValidarSessaoPedido()
		public static string ValidarSessaoPedido()
		{
			if (HttpContext.Current.Session[PIZZA_PEDIDO_SESSION] == null)
				return null;

			return HttpContext.Current.Session[PIZZA_PEDIDO_SESSION].ToString();
		}
		#endregion

	}
}