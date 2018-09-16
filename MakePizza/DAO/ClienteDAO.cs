using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MakePizza.Models;

namespace MakePizza.DAO
{
	public class ClienteDAO
	{
		private static Contexto contexto = SingletonContexto.GetInstance();

		public static bool CadastrarCliente(Cliente cliente)
		{
			if(BuscarClientePorNome(cliente) == null)
			{
				contexto.Clientes.Add(cliente);
				contexto.SaveChanges();
				return true;
			}
			return false;
		}

		public static Cliente BuscarClientePorNome(Cliente cliente)
		{
			return contexto.Clientes.FirstOrDefault(_ => _.NomeCliente.Equals(cliente.NomeCliente) &&
													_.SenhaCliente.Equals(cliente.SenhaCliente));
		}
	}
}