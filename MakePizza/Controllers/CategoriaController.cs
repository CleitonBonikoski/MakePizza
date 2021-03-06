﻿using MakePizza.DAO;
using MakePizza.Models;
using MakePizza.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MakePizza.Controllers
{
	public class CategoriaController : Controller
	{
		private string SessaoClienteAtual = Sessao.ValidarSessaoCliente();

		#region Home()
		public ActionResult Home()
		{
            if (SessaoClienteAtual == null)
                return RedirectToAction("Home", "Cliente");

            return View(CategoriaDAO.RetornarCategorias());
		}
		#endregion

		#region CadastrarCategoria()
		public ActionResult CadastrarCategoria()
		{
			if (SessaoClienteAtual == null)
				return RedirectToAction("Home", "Cliente");

			return View();
		}
		#endregion

		#region CadastrarCategoria(Categoria)
		[HttpPost]
		public ActionResult CadastrarCategoria(Categoria categoria)
		{
			if (CategoriaDAO.CadastrarCategoria(categoria))
				return RedirectToAction("CadastrarIngrediente", "Ingrediente");

			return View();
		}
		#endregion

		#region RemoverCategoria(id)
		public ActionResult RemoverCategoria(int id)
		{
            if (SessaoClienteAtual == null)
                return RedirectToAction("Home", "Cliente");

            CategoriaDAO.RemoverCategoria(id);
			return RedirectToAction("Home", "Categoria");
		}
		#endregion

		#region AlterarCategoria(id)
		public ActionResult AlterarCategoria(int id)
		{
            if (SessaoClienteAtual == null)
                return RedirectToAction("Home", "Cliente");

            return View(CategoriaDAO.BuscarCategoriaPorId(id));
		}
		#endregion

		#region HttpPost Alterar Categoria(Categoria)
		[HttpPost]
		public ActionResult AlterarCategoria(Categoria categoriaAlterada)
		{
			Categoria categoriaOriginal =
				CategoriaDAO.BuscarCategoriaPorId(categoriaAlterada.IdCategoria);

			categoriaOriginal.NomeCategoria = categoriaAlterada.NomeCategoria;
			categoriaOriginal.DescricaoCategoria = categoriaAlterada.DescricaoCategoria;
			categoriaOriginal.StatusCategoria = categoriaAlterada.StatusCategoria;

			if (ModelState.IsValid)
			{
				if (CategoriaDAO.AlterarCategoria(categoriaOriginal))
				{
					return RedirectToAction("Home", "Categoria");
				}
				else
				{
					ModelState.AddModelError("", "Não é possível alterar uma categoria com o mesmo nome!");
					return View(categoriaOriginal);
				}
			}
			else
			{
				return View(categoriaOriginal);
			}
		}
		#endregion
	}
}