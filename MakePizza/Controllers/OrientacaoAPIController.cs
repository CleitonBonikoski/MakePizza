using MakePizza.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MakePizza.Controllers
{
    public class OrientacaoAPIController : Controller
    {
        private string SessaoClienteAtual = Sessao.ValidarSessaoCliente();

        // GET: OrientacaoAPI
        public ActionResult Home()
        {
            return View();
        }
    }
}