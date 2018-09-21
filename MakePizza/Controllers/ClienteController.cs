using MakePizza.DAO;
using MakePizza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MakePizza.Controllers
{
	public class ClienteController : Controller
	{
		#region Home()
		public ActionResult Home()
		{
			return View();
		}
		#endregion

		#region Login(Cliente)
		[HttpPost]
		public ActionResult Login(Cliente cliente)
		{
			try
			{
				Cliente clienteNovo = ClienteDAO.BuscarClientePorEmail(cliente);

				if (clienteNovo.AdminCliente)
					return RedirectToAction("Home", "EscolhaCadastro");

				return RedirectToAction("AddIngredientesNaPizza", "Pizza");
			}
			catch (Exception)
			{
				return RedirectToAction("Home", "Cliente");
			}
		}
		#endregion

		#region CadastrarCliente()
		public ActionResult CadastrarCliente()
		{
			return View();
		}
		#endregion

		#region CadastrarCliente(Cliente)
		[HttpPost]
		public ActionResult CadastrarCliente(Cliente cliente)
		{
			if (ClienteDAO.CadastrarCliente(cliente))
				return RedirectToAction("Home", "Cliente");

			return View();
		}
		#endregion
	}
}