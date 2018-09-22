using MakePizza.DAO;
using MakePizza.Models;
using MakePizza.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MakePizza.Controllers
{
	public class PizzaController : Controller
	{
		private string Ingrediente_Pizza_Sessao ; 
		#region Home()
		public ActionResult Home()
		{
			string sessaoPizza = Sessao.CriarSessaoPizza();
			ViewBag.lstIngredientes = Ingrediente_PizzaDAO.RetornarTodosNaSessao(sessaoPizza);
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
			string sessaoPizza = Sessao.CriarSessaoPizza();
			pizza.GuidPizza = sessaoPizza;
			pizza.GuidPedido = Sessao.CriarSessaoPedido();
			pizza.DataPizza = DateTime.Now;
			pizza.lstIngredientes = Ingrediente_PizzaDAO.RetornarTodosNaSessao(sessaoPizza);
			if (PizzaDAO.CadastrarPizza(pizza))
				if(Pizza_PedidoDAO)
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

		#region AddIngredientesNaPizza(int[])
		[HttpPost]
		public ActionResult AddIngredientesNaPizza(int[] IdCheckBox)
		{
			if (IdCheckBox != null)
			{
				Ingrediente_Pizza_Sessao = Sessao.CriarSessaoPizza();

				foreach (int idIngrediente in IdCheckBox)
				{
					Ingrediente ingrediente = IngredienteDAO.BuscarIngredientePorId(idIngrediente);
					Ingrediente_Pizza ingrediente_Pizza = new Ingrediente_Pizza
					{
						ingredientePizza = ingrediente ,
						DataIngrediente_Pizza = DateTime.Now,
						GuidPizza = Ingrediente_Pizza_Sessao
					};
					Ingrediente_PizzaDAO.CadastrarIngredientePizza(ingrediente_Pizza);
				}
				return RedirectToAction("Home", "Pizza");
			}

			ViewBag.Ingredientes = IngredienteDAO.RetornarIngredientes();

			return View();

		}
		#endregion

	}
}