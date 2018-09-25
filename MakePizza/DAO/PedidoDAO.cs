using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MakePizza.Models;

namespace MakePizza.DAO
{
	public class PedidoDAO
	{
		#region Contexto
		private static Contexto contexto = SingletonContexto.GetInstance();
		#endregion

		public static bool CadastrarPedido(Pedido pedido)
		{
			try
			{
				contexto.Pedidos.Add(pedido);
				contexto.SaveChanges();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

        public static List<Pedido> RetornarPedidos()
        {
            return contexto.Pedidos.Include("NomeCliente").ToList();
        }
    }
}