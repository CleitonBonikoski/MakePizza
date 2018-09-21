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

		private static string PEDIDO_SESSION = "GuidPedido";
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

		#region  CriarSessaoPedido()
		public static string CriarSessaoPedido()
		{
			if (HttpContext.Current.Session[PEDIDO_SESSION] == null)
			{
				Guid guid = Guid.NewGuid();
				HttpContext.Current.Session[PEDIDO_SESSION] = guid;
			}
			return HttpContext.Current.Session[PEDIDO_SESSION].ToString();
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

		#region ValidarSessaoPedido()
		public static string ValidarSessaoPedido()
		{
			if (HttpContext.Current.Session[PEDIDO_SESSION] == null)
				return null;

			return HttpContext.Current.Session[PEDIDO_SESSION].ToString();
		}
		#endregion

	}
}