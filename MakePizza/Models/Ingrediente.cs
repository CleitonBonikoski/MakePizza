﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MakePizza.Models
{
	[Table("Ingrediente")]
	public class Ingrediente
	{
		#region Propriedades

		[Key]
		public int IdIngrediente { get; set; }

		[Display(Name = "Nome Categoria")]
		public Categoria CategoriaIngrediente { get; set; }

		[Display(Name = "Nome Ingrediente")]
		[Required(ErrorMessage = "Nome Obrigatório ")]
		public string NomeIngrediente { get; set; }

		[Display(Name = "Preço Ingrediente")]
		[Required(ErrorMessage = "Nome Obrigatório ")]
		public double PrecoIngrediente { get; set; }

		//Valores válidos para Status : Disponivel e Indisponível.
		[Display(Name = "Status Ingrediente")]
		public bool StatusIngrediente { get; set; }

		[Display(Name = "Peso Ingrediente")]
		public string PesoIngrediente { get; set; }

		#endregion
	}
}