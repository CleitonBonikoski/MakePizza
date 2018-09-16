using MakePizza.DAO;
using MakePizza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MakePizza.Controllers
{
	public class CategoriaController : Controller
	{
		#region Home()
		public ActionResult Home()
		{
			return View();
		}
		#endregion

		#region CadastrarCategoria()
		public ActionResult CadastrarCategoria()
		{
			return View();
		}
		#endregion

		#region CadastrarCategoria(Categoria)
		[HttpPost]
		public ActionResult CadastrarCategoria(Categoria categoria)
		{
			if(CategoriaDAO.CadastrarCategoria(categoria))
				return RedirectToAction("CadastrarIngrediente","Ingrediente");
				
			return View();
		}
		#endregion
	}
}