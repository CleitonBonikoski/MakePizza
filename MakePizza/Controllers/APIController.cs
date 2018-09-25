using MakePizza.DAO;
using MakePizza.Models;
using MakePizza.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MakePizza.Controllers
{
    

    [RoutePrefix("API/Cadastros")]
    public class APIController : ApiController
    {     
        //#region Listar Ingredientes por ID
        //[Route("Ingredientes")]
        //public dynamic GetIngredientesPorId(int IdIngrediente)
        //{
        //    Ingrediente ingrediente = IngredienteDAO.BuscarIngredientePorId(IdIngrediente);
        //    List<Categoria> categorias = CategoriaDAO.RetornarCategorias();
        //    if (ingrediente != null)
        //    {
        //        dynamic ingredienteDinamico = new
        //        {
        //            Nome = ingrediente.NomeIngrediente,
        //            Categoria = ingrediente.CategoriaIngrediente,
        //            Preco = ingrediente.PrecoIngrediente.ToString("C2"),
        //            Disponibilidade = ingrediente.StatusIngrediente
        //        };
        //        return new { Ingrediente = ingredienteDinamico };
        //    }
        //    return null;
        //}
        //#endregion

        #region Listar Ingredientes
        [Route("Ingredientes")]
        public List<Ingrediente> GetIngredientes()
        {

            return IngredienteDAO.RetornarIngredientes();
        }
        #endregion

        #region Listar Categorias
        [Route("Categorias")]
        public List<Categoria> GetCategorias()
        {
            return CategoriaDAO.RetornarCategorias();
        }
        #endregion

        #region Listar Clientes
        [Route("Clientes")]
        public List<Cliente> GetClientes()
        {
            return ClienteDAO.RetornarClientes();
        }
        #endregion
    }
}
