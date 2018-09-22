using MakePizza.DAO;
using MakePizza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MakePizza.Controllers
{
    [RoutePrefix("API/Cadastros")]
    public class IngredientesAPIController : ApiController
    {
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
