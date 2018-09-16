using MakePizza.DAO;
using MakePizza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MakePizza.Controllers
{
	public class IngredienteController : Controller
	{
		#region Home()
		public ActionResult Home()
		{
			return View();
		}
		#endregion

		#region CadastrarIngrediente()
		public ActionResult CadastrarIngrediente()
		{
			return View();
		}
		#endregion

		#region CadastrarIngrediente()
		[HttpPost]
		public ActionResult CadastrarIngrediente(Ingrediente ingrediente)
		{
			if (IngredienteDAO.CadastrarIngrediente(ingrediente))
				return RedirectToAction("CadastrarPizza", "Pizza");

			return View();
		}
		#endregion
	}
}