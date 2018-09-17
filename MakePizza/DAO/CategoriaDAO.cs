using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MakePizza.Models;

namespace MakePizza.DAO
{
	public class CategoriaDAO
	{
		#region Contexto
		private static Contexto contexto = SingletonContexto.GetInstance();
		#endregion

		#region CadastrarCategoria(Categoria)
		public static bool CadastrarCategoria(Categoria categoria)
		{
			if (BuscarCategoriaPorNome(categoria) == null)
			{
				contexto.Categorias.Add(categoria);
				contexto.SaveChanges();
				return true;
			}
			return false;
		}
		#endregion

		#region RetornarCategorias()
		public static List<Categoria> RetornarCategorias()
		{
			return contexto.Categorias.ToList();
		}
		#endregion

		#region  BuscarCategoriaPorId(int?)
		public static Categoria BuscarCategoriaPorId(int? idCategoria)
		{
			return contexto.Categorias.FirstOrDefault(_ => _.IdCategoria == idCategoria);
		}
		#endregion

		#region BuscarCategoriaPorNome(Categoria)
		public static Categoria BuscarCategoriaPorNome(Categoria categoria)
		{
			return contexto.Categorias.FirstOrDefault(_ => _.NomeCategoria.Equals(categoria.NomeCategoria));
		}
		#endregion
	}
}