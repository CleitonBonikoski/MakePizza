using MakePizza.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MakePizza.Controllers
{
	public class PedidoController : Controller
	{
		// GET: Pedido
		public ActionResult Home()
		{
			ViewBag.Pizzas = PizzaDAO.RetornarPizzaPedido();
			return View();
		}
	}
}