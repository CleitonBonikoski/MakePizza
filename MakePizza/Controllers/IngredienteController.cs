using MakePizza.DAO;
using MakePizza.Models;
using MakePizza.Utils;
using System.Web.Mvc;

namespace MakePizza.Controllers
{
    public class IngredienteController : Controller
    {
        private string SessaoClienteAtual = Sessao.ValidarSessaoCliente();

        #region Home()
        public ActionResult Home()
        {
            if (SessaoClienteAtual == null)
                return RedirectToAction("Home", "Cliente");

            return View(IngredienteDAO.RetornarIngredientes());
        }
        #endregion

        #region CadastrarIngrediente()
        public ActionResult CadastrarIngrediente()
        {
            if (SessaoClienteAtual == null)
                return RedirectToAction("Home", "Cliente");

            ViewBag.Categorias =
                new MultiSelectList(CategoriaDAO.RetornarCategorias(),
                "IdCategoria", "NomeCategoria");
            return View();
        }
        #endregion

        #region HttpPost CadastrarIngrediente(Ingrediente)
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
            if (SessaoClienteAtual == null)
                return RedirectToAction("Home", "Cliente");

            ViewBag.Categorias =
                new MultiSelectList(CategoriaDAO.RetornarCategorias(),
                "IdCategoria", "NomeCategoria");

            return View(IngredienteDAO.BuscarIngredientePorId(id));
        }
        #endregion

        #region HttpsPost AlterarIngrediente(IngredienteAlterado)
        [HttpPost]
        public ActionResult AlterarIngrediente(Ingrediente ingredienteAlterado, int? Categorias)
        {


            ViewBag.Categorias = CategoriaDAO.RetornarCategorias();

            ingredienteAlterado.CategoriaIngrediente = CategoriaDAO.BuscarCategoriaPorId(Categorias);

            Ingrediente ingredienteOriginal =
                IngredienteDAO.BuscarIngredientePorId(ingredienteAlterado.IdIngrediente);

            if (ModelState.IsValid && Categorias != null)
            {
                ingredienteOriginal.NomeIngrediente = ingredienteAlterado.NomeIngrediente;
                ingredienteOriginal.PrecoIngrediente = ingredienteAlterado.PrecoIngrediente;
                ingredienteOriginal.PesoIngrediente = ingredienteAlterado.PesoIngrediente;
				ingredienteOriginal.CategoriaIngrediente = ingredienteAlterado.CategoriaIngrediente;
                ingredienteOriginal.StatusIngrediente = ingredienteAlterado.StatusIngrediente;


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
                ModelState.AddModelError("", "Selecione uma Categoria Válida!");
                return View(ingredienteOriginal);
            }
        }
        #endregion
    }
}