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
		// GET: Cliente
		public ActionResult Home()
		{
			return View();
		}

		public ActionResult CadastrarCliente()
		{
			return View();
		}

		[HttpPost]
		public ActionResult CadastrarCliente(Cliente cliente)
		{
			if (ClienteDAO.CadastrarCliente(cliente))
				return RedirectToAction("Home", "Cliente");

			return View();
		}
	}
}