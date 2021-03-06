﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
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

		public static List<Ingrediente> RetornarIngredientes()
		{
			return contexto.Ingredientes.Include("CategoriaIngrediente").ToList();
		}

        internal static bool AlterarIngrediente(Ingrediente ingredienteOriginal)
        {
            if (contexto.Ingredientes.FirstOrDefault
                (x => x.NomeIngrediente.Equals(ingredienteOriginal.NomeIngrediente) &&
                x.IdIngrediente != ingredienteOriginal.IdIngrediente) == null)
            {
                contexto.Entry(ingredienteOriginal).State = EntityState.Modified;
                contexto.SaveChanges();
                return true;
            }
            return false;
        }
    }
}