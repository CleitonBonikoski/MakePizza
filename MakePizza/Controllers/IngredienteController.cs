using MakePizza.DAO;
using MakePizza.Models;
using System.Web.Mvc;

namespace MakePizza.Controllers
{
	public class IngredienteController : Controller
	{
		#region Home()
		public ActionResult Home()
		{
			return View();
		}
		#endregion

		#region CadastrarIngrediente()
		public ActionResult CadastrarIngrediente()
		{
			ViewBag.Categorias =
				new SelectList(CategoriaDAO.RetornarCategorias(),
				"IdCategoria", "NomeCategoria");
			return View();
		}
		#endregion

		#region CadastrarIngrediente()
		[HttpPost]
		public ActionResult CadastrarIngrediente(Ingrediente ingrediente)
		{
			if (IngredienteDAO.CadastrarIngrediente(ingrediente))
				return RedirectToAction("CadastrarPizza", "Pizza");

			return View();
		}
		#endregion
	}
}