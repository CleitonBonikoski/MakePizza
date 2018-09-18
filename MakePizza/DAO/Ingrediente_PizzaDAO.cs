using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MakePizza.Models;

namespace MakePizza.DAO
{
	public class Ingrediente_PizzaDAO
	{
		#region Contexto
		private static Contexto contexto = SingletonContexto.GetInstance();
		#endregion

		public static bool CadastrarIngredientePizza(Ingrediente_Pizza ingrediente_Pizza)
		{
			try
			{
				contexto.Ingredientes_Pizza.Add(ingrediente_Pizza);
				contexto.SaveChanges();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}
	}
}