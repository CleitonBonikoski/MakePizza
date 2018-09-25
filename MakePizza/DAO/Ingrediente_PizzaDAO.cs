using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MakePizza.Models;
using MakePizza.Utils;

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

		public static List<Ingrediente_Pizza> RetornarTodos()
		{
			return contexto.Ingredientes_Pizza.ToList();
		}

		public static List<Ingrediente_Pizza> RetornarTodosNaSessao(string sessaoPizza)
		{
			return contexto.Ingredientes_Pizza.Where(_ => _.GuidPizza.Equals(sessaoPizza)).ToList();
		}

		public static bool AtualizarIngrediente_Pizza(Ingrediente_Pizza ingrediente_Pizza)
		{
			try
			{
				CadastrarIngredientePizza(ingrediente_Pizza);
				return true;
			}
			catch (Exception)
			{
				return false;
			}
			
		}
	}
}