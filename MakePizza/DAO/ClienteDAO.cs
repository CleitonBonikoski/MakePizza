using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MakePizza.Models;

namespace MakePizza.DAO
{
    public class ClienteDAO
    {
        #region Contexto
        private static Contexto contexto = SingletonContexto.GetInstance();
        #endregion

        #region CadastrarCliente(Cliente)
        public static bool CadastrarCliente(Cliente cliente)
        {
            if (BuscarClientePorNome(cliente) == null)
            {
                cliente.AdminCliente = false;
                contexto.Clientes.Add(cliente);
                contexto.SaveChanges();
                return true;
            }
            return false;
        }
        #endregion

        #region Retornar Clientes()
        public static List<Cliente> RetornarClientes()
        {
            return contexto.Clientes.ToList();
        }
        #endregion

        #region BuscarClientePorEmailSenha(Cliente)
        public static Cliente BuscarClientePorEmailSenha(Cliente cliente)
        {
            return contexto.Clientes.FirstOrDefault(_ => _.EmailCliente.Equals(cliente.EmailCliente) &&
                                                    _.SenhaCliente.Equals(cliente.SenhaCliente));
        }
		#endregion

		#region BuscarClientePorEmail(string)
		public static Cliente BuscarClientePorEmail(string email)
		{
			return contexto.Clientes.FirstOrDefault(_ => _.EmailCliente.Equals(email));
		}
		#endregion

		#region BuscarClientePorNome(Cliente)
		public static Cliente BuscarClientePorNome(Cliente cliente)
        {
            return contexto.Clientes.FirstOrDefault(_ => _.NomeCliente.Equals(cliente.NomeCliente) &&
                                                    _.SenhaCliente.Equals(cliente.SenhaCliente));
        }
        #endregion
    }
}