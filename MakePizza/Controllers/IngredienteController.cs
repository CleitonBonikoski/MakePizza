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
            return View(IngredienteDAO.RetornarIngredientes());
        }
        #endregion

        #region CadastrarIngrediente()
        public ActionResult CadastrarIngrediente()
        {
            ViewBag.Categorias =
                new MultiSelectList(CategoriaDAO.RetornarCategorias(),
                "IdCategoria", "NomeCategoria");
            return View();
        }
        #endregion

        #region CadastrarIngrediente(Ingrediente)
        [HttpPost]
        public ActionResult CadastrarIngrediente(Ingrediente ingrediente, int? Categorias)
        {
            ViewBag.Categorias = new SelectList(CategoriaDAO.RetornarCategorias(), "IdCategoria", "NomeCategoria");

            if (ModelState.IsValid)
            {
                if (Categorias != null)
                {
                    ingrediente.CategoriaIngrediente = CategoriaDAO.BuscarCategoriaPorId(Categorias);
                    if (IngredienteDAO.CadastrarIngrediente(ingrediente))
                    {
                        return RedirectToAction("Home", "Ingrediente");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Não é possível adicionar um ingrediente com o mesmo nome!");
                        return View(ingrediente);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Por favor, selecione uma categoria!");
                    return View(ingrediente);
                }
            }
            else
            {
                return View();
            }
        }
        #endregion

        #region AlterarIngrediente(id)
        public ActionResult AlterarIngrediente(int id)
        {
            return View(IngredienteDAO.BuscarIngredientePorId(id));
        }
        #endregion

        #region HttpsPost AlterarIngrediente(IngredienteAlterado)
        [HttpPost]
        public ActionResult AlterarIngrediente(Ingrediente ingredienteAlterado)
        {
            Ingrediente ingredienteOriginal =
                IngredienteDAO.BuscarIngredientePorId(ingredienteAlterado.IdIngrediente);

            ingredienteOriginal.NomeIngrediente = ingredienteAlterado.NomeIngrediente;
            ingredienteOriginal.PrecoIngrediente = ingredienteAlterado.PrecoIngrediente;
            ingredienteOriginal.CategoriaIngrediente = ingredienteAlterado.CategoriaIngrediente;
            ingredienteOriginal.StatusIngrediente = ingredienteAlterado.StatusIngrediente;

            if (ModelState.IsValid)
            {
                if (IngredienteDAO.AlterarIngrediente(ingredienteOriginal))
                {
                    return RedirectToAction("Home", "Ingrediente");
                }
                else
                {
                    ModelState.AddModelError("", "Não é possível alterar um ingrediente com o mesmo nome!");
                    return View(ingredienteOriginal);
                }
            }
            else
            {
                return View(ingredienteOriginal);
            }
        }
        #endregion
    }
}