using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MakePizza.Models;

namespace MakePizza.DAO
{
	public class IngredienteDAO
	{
		#region Contexto
		private static Contexto contexto = SingletonContexto.GetInstance();
		#endregion

		public static bool CadastrarIngrediente(Ingrediente ingrediente)
		{
			if(BuscarIngredientePorNome(ingrediente) == null)
			{
				contexto.Ingredientes.Add(ingrediente);
				contexto.SaveChanges();
				return true;
			}
			return false;
		}

		public static Ingrediente BuscarIngredientePorNome(Ingrediente ingrediente)
		{
			return contexto.Ingredientes.FirstOrDefault(_ => _.NomeIngrediente.Equals(ingrediente.NomeIngrediente));
		}

		public static Ingrediente BuscarIngredientePorId(int? idIngrediente)
		{
			return contexto.Ingredientes.Find(idIngrediente);	
		}

		internal static IEnumerable RetornarIngredientes()
		{
			return contexto.Ingredientes.ToList();
		}
	}
}