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
	public class PedidoController : Controller
	{
		// GET: Pedido
		public ActionResult Home()
		{
			ViewBag.Pizzas = PizzaDAO.RetornarPizzaPedido();
			return View();
		}

		[HttpPost]
		public ActionResult Home(int[] lstIdPizzaConfirmado, string emailCliente, double precoPedido)
		{
			if (lstIdPizzaConfirmado != null)
			{
				List<Pizza> lstPizzasConfirmadas = new List<Pizza>();

				List<Pizza_Pedido> lstPizzas_PedidoConfirmadas = new List<Pizza_Pedido>();

				foreach (int IdPizzaConfirmada in lstIdPizzaConfirmado)
					lstPizzasConfirmadas.Add(PizzaDAO.RetornarPizzaPedidoPorId(IdPizzaConfirmada));

				Cliente cliente = ClienteDAO.BuscarClientePorEmail(emailCliente);

				Pedido pedido = new Pedido
				{
					ClientePedido = cliente,
					DataPedido = DateTime.Now,
					GuidPedido = Sessao.ValidarSessaoPedido(),
					PizzasPedido = lstPizzas_PedidoConfirmadas,
					PrecoTotalPedido = precoPedido,
					StatusPedido = "Finalizado"
				};
				if (PedidoDAO.CadastrarPedido(pedido))
					return RedirectToAction("Home", "Pizza");
			}

			ViewBag.Pizzas = PizzaDAO.RetornarPizzaPedido();
			return View();
		}
	}
}