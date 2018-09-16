using MakePizza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakePizza.DAO
{
	public class SingletonContexto
	{
		private static Contexto contexto;

		private SingletonContexto() { }

		#region GetInstance()
		public static Contexto GetInstance()
		{
			if (contexto == null)
			{
				contexto = new Contexto();
			}
			return contexto;
		}
		#endregion
	}
}