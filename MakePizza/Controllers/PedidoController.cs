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
        private string SessaoClienteAtual = Sessao.ValidarSessaoCliente();

        // GET: Pedido
        public ActionResult Home()
		{
            if (SessaoClienteAtual == null)
                return RedirectToAction("Home", "Cliente");

            ViewBag.Pizzas = PizzaDAO.RetornarPizzaPedido();
			return View();
		}

		[HttpPost]
		public ActionResult Home(int[] lstIdPizzaConfirmado, Pedido pedido)
		{
			List<Pizza> retornoPizzaPedido = PizzaDAO.RetornarPizzaPedido();

			double valorTotalPedido = 0;

			foreach (var pizza in retornoPizzaPedido)
			{
				valorTotalPedido += pizza.PrecoPizza;
			}

			if (lstIdPizzaConfirmado != null)
			{
				List<Pizza> lstPizzasConfirmadas = new List<Pizza>();

				foreach (int IdPizzaConfirmada in lstIdPizzaConfirmado)
					lstPizzasConfirmadas.Add(PizzaDAO.RetornarPizzaPedidoPorId(IdPizzaConfirmada));

				if (retornoPizzaPedido.Count == lstPizzasConfirmadas.Count)
				{
					Cliente cliente = ClienteDAO.BuscarClientePorEmail(pedido.ClientePedido);

					string sessaoPedidoAtual = Sessao.ValidarSessaoPizza_Pedido();

					pedido.PrecoTotalPedido = valorTotalPedido;
					pedido.PizzasPedido = Pizza_PedidoDAO.RetornarPizza_PedidoPorGuid(sessaoPedidoAtual);
					pedido.ClientePedido = cliente;
					pedido.DataPedido = DateTime.Now;
					pedido.GuidPedido = sessaoPedidoAtual;

					if (PedidoDAO.CadastrarPedido(pedido))
						if (Sessao.KillTodasAsSessoes())
							return RedirectToAction("Home", "Cliente");

					return RedirectToAction("AddIngredientesNaPizza", "Pizza");

				}

			}

			ViewBag.Pizzas = retornoPizzaPedido;
			return View();
		}

		public ActionResult RemoverPizzaDoPedido()
		{
            if (SessaoClienteAtual == null)
                return RedirectToAction("Home", "Cliente");

            ViewBag.Pizzas = PizzaDAO.RetornarPizzaPedido();
			return View();
		}

        public ActionResult ListaPedidos()
        {
            return View(PedidoDAO.RetornarPedidos());
        }

	}
}