using MakePizza.DAO;
using MakePizza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MakePizza.Controllers
{
	public class PizzaController : Controller
	{
		#region Home()
		public ActionResult Home()
		{
			return View();
		}
		#endregion

		#region CadastrarPizza()
		public ActionResult CadastrarPizza()
		{
			return View();
		}
		#endregion

		#region CadastrarPizza(Pizza)
		[HttpPost]
		public ActionResult CadastrarPizza(Pizza pizza)
		{
			if (PizzaDAO.CadastrarPizza(pizza))
				return RedirectToAction("Home", "Pedido");

			return View();
		}
		#endregion

		#region MostrarPizza()
		public ActionResult MostrarPizza()
		{
			return View();
		}
		#endregion

		#region AddIngredientesNaPizza()
		public ActionResult AddIngredientesNaPizza()
		{
			ViewBag.Ingredientes = IngredienteDAO.RetornarIngredientes();
			return View();
		}
		#endregion

		#region AddIngredientesNaPizza(Pizza)
		[HttpPost]
		public ActionResult AddIngredientesNaPizza(int[] IdCheckBox)
		{
			ViewBag.Ingredientes = IngredienteDAO.RetornarIngredientes();

			if (IdCheckBox != null)
			{
				foreach (int idIngrediente in IdCheckBox)
				{
					Ingrediente ingrediente = IngredienteDAO.BuscarIngredientePorId(idIngrediente);
					Ingrediente_Pizza ingrediente_Pizza = new Ingrediente_Pizza
					{
						ingredientePizza = ingrediente
					};
					Ingrediente_PizzaDAO.CadastrarIngredientePizza(ingrediente_Pizza);
				}
				return View();
			}
			return RedirectToAction("Home", "Pizza");
		}
		#endregion

	}
}