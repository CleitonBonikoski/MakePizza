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
			ViewBag.Ingredientes =
				new SelectList(IngredienteDAO.RetornarIngredientes(),
				"IdIngrediente", "NomeIngrediente");
			return View();
		}
		#endregion

		#region AddIngredientesNaPizza(Pizza)
		[HttpPost]
		public ActionResult AddIngredientesNaPizza(int? IdIngrediente)
		{
			if (IdIngrediente != null)
			{
				Ingrediente ingrediente = IngredienteDAO.BuscarIngredientePorId(IdIngrediente);
				Ingrediente_Pizza ingrediente_Pizza = new Ingrediente_Pizza
				{
					ingredientePizza = ingrediente
				};
				Ingrediente_PizzaDAO.CadastrarIngredientePizza(ingrediente_Pizza);
				return View();

			}
			return RedirectToAction("Home", "Pizza");
		}
		#endregion

	}
}