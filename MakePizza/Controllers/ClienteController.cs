using MakePizza.DAO;
using MakePizza.Models;
using MakePizza.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Web.Security;

namespace MakePizza.Controllers
{
    public class ClienteController : Controller
    {
        private string SessaoClienteAtual = Sessao.ValidarSessaoCliente();

        #region Home()
        public ActionResult Home()
        {
            return View();
        }
        #endregion

        #region Listar Clientes
        public ActionResult Listar()
        {
            if (SessaoClienteAtual == null)
                return RedirectToAction("Home", "Cliente");

            return View(ClienteDAO.RetornarClientes());
        }
        #endregion

        #region Login(Cliente)
        [HttpPost]
        public ActionResult Login(Cliente cliente)
        {
            //try
            //{
            //	Cliente clienteLogado = ClienteDAO.BuscarClientePorEmailSenha(cliente);
            //	if (clienteLogado != null)
            //		Sessao.CriarSessaoCliente();

            //	if (clienteLogado.AdminCliente)
            //		return RedirectToAction("Home", "EscolhaCadastro");

            //	return RedirectToAction("AddIngredientesNaPizza", "Pizza");
            //}
            //catch (Exception)
            //{
            //	return RedirectToAction("Home", "Cliente");
            //}

            cliente = ClienteDAO.BuscarClientePorEmailSenha(cliente);
            if (cliente != null)
            {
                FormsAuthentication.SetAuthCookie(cliente.EmailCliente, true);
                Sessao.CriarSessaoCliente();
                if (cliente.AdminCliente)
                {
                    return RedirectToAction("Home", "EscolhaCadastro");
                }
                return RedirectToAction("AddIngredientesNaPizza", "Pizza");
            }
            else
            {
                ModelState.AddModelError("", "O e-mail ou senha não coincidem!");
                return RedirectToAction("Home", "Cliente");
            }
        }
        #endregion

        #region Logout(CLiente)
        public ActionResult Logout()
        {
            Sessao.KillTodasAsSessoes();
            return RedirectToAction("Home", "Cliente");
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
            if (ModelState.IsValid)
            {
                //Validate Google recaptcha
                var response = Request["g-recaptcha-response"];
                string secretKey = "6Lc2fHEUAAAAAAyjcmujO_634iiSEkZd1ikm9SuI";
                var client = new WebClient();
                var result = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secretKey, response));
                var obj = JObject.Parse(result);
                var status = (bool)obj.SelectToken("success");
                ViewBag.Message = status ? "Google reCaptcha validation sucess" : "Google reCaptcha validation failed";

                if (ViewBag.Message == "Google reCaptcha validation sucess")
                {
                    if (ClienteDAO.CadastrarCliente(cliente))
                    {
                        return RedirectToAction("Home", "Cliente");
                    }
                ModelState.AddModelError("", "Esse email já existe!");
                }
            }
            return View(cliente);
        }
        #endregion
    }
}