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

		#region CadastrarIngrediente(Ingrediente)
		[HttpPost]
		public ActionResult CadastrarIngrediente(Ingrediente ingrediente)
		{
			if(ingrediente.CategoriaIngrediente.IdCategoria > 0)
			{
				ingrediente.CategoriaIngrediente = CategoriaDAO.BuscarCategoriaPorId(ingrediente.CategoriaIngrediente.IdCategoria);

				if (IngredienteDAO.CadastrarIngrediente(ingrediente))
					return RedirectToAction("AddIngredientesNaPizza", "Pizza");
			}
			return View();
		}
		#endregion
	}
}