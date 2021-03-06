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
	public class PizzaController : Controller
	{
		private string SessaoClienteAtual = Sessao.ValidarSessaoCliente();

		private string Ingrediente_Pizza_Sessao;

		#region Home()
		public ActionResult Home()
		{
			if (SessaoClienteAtual == null)
				return RedirectToAction("Home", "Cliente");

			string sessaoPizza = Sessao.CriarSessaoIngrediente_Pizza();
			ViewBag.lstIngredientes = Ingrediente_PizzaDAO.RetornarTodosNaSessao(sessaoPizza);
			return View();
		}
		#endregion

		#region Listar Pizzas
		public ActionResult Listar()
		{
			if (SessaoClienteAtual == null)
				return RedirectToAction("Home", "Cliente");

			return View();
		}
		#endregion

		#region CadastrarPizza()
		public ActionResult CadastrarPizza()
		{
			string sessaoPizza = Sessao.CriarSessaoIngrediente_Pizza();
			ViewBag.Ingredientes = Ingrediente_PizzaDAO.RetornarTodosNaSessao(sessaoPizza);
			return View();
		}
		#endregion

		#region CadastrarPizza(Pizza)
		[HttpPost]
		public ActionResult CadastrarPizza(Pizza novaPizza)
		{
			string sessaoPizza = Sessao.CriarSessaoIngrediente_Pizza();

			List<Ingrediente_Pizza> lstIngrediente_Pizza = Ingrediente_PizzaDAO.RetornarTodosNaSessao(sessaoPizza);

			double valorTotaldeIngredientePizza = 0;

			foreach (var ingrediente in lstIngrediente_Pizza)
			{
				valorTotaldeIngredientePizza += ingrediente.ingredientePizza.PrecoIngrediente;
			}

			novaPizza.PrecoPizza = valorTotaldeIngredientePizza;
			novaPizza.GuidPizza = sessaoPizza;
			novaPizza.GuidPedido = Sessao.CriarSessaoPizza_Pedido();
			novaPizza.DataPizza = DateTime.Now;
			novaPizza.lstIngredientes = Ingrediente_PizzaDAO.RetornarTodosNaSessao(sessaoPizza);

			if (PizzaDAO.CadastrarPizza(novaPizza))
			{
				Pizza_Pedido pizza_Pedido = new Pizza_Pedido
				{
					pizza = novaPizza,
					DataPizza_Pedido = DateTime.Now,
					GuidPedido = Sessao.CriarSessaoPizza_Pedido()
				};



				if (Pizza_PedidoDAO.CadastrarPizza_Pedido(pizza_Pedido))
					return RedirectToAction("Home", "Pedido");
			}

			ViewBag.Ingredientes = lstIngrediente_Pizza;
			return View();
		}
		#endregion

		#region MostrarPizza()
		public ActionResult MostrarPizza()
		{
			if (SessaoClienteAtual == null)
				return RedirectToAction("Home", "Cliente");

			return View();
		}
		#endregion

		#region AddIngredientesNaPizza()
		public ActionResult AddIngredientesNaPizza()
		{
			if (SessaoClienteAtual == null)
				return RedirectToAction("Home", "Cliente");

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
				Ingrediente_Pizza_Sessao = Sessao.CriarNovaGuidSessaoIngrediente_Pizza();

				foreach (int idIngrediente in IdCheckBox)
				{
					Ingrediente ingrediente = IngredienteDAO.BuscarIngredientePorId(idIngrediente);
					Ingrediente_Pizza ingrediente_Pizza = new Ingrediente_Pizza
					{
						ingredientePizza = ingrediente,
						DataIngrediente_Pizza = DateTime.Now,
						GuidPizza = Ingrediente_Pizza_Sessao,
						GuidPedido = Sessao.CriarSessaoPizza_Pedido()

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