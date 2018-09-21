using MakePizza.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MakePizza.Controllers
{
    public class EscolhaCadastroController : Controller
    {
		private string SessaoClienteAtual = Sessao.ValidarSessaoCliente();

		// GET: EscolhaCadastrar
		public ActionResult Home()
        {
			if (SessaoClienteAtual == null)
				return RedirectToAction("Home", "Cliente");

			return View();
        }
    }
}