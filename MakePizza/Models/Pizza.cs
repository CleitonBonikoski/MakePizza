﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MakePizza.Models
{
	[Table("Pizza")]
	public class Pizza
	{
		#region Propriedades

		[Key]
		public int IdPizza { get; set; }

		[Display(Name = " Ingredientes ")]
		public List<Ingrediente_Pizza> lstIngredientes { get; set; }

		[Display(Name ="Nome da Sua Pizza")]
		public string NomePizza { get; set; }

		[Display(Name = "P - M - G - GG ")]
		[Required(ErrorMessage = "Tamanho Obrigatório ")]
		public string TamanhoPizza { get; set; }

		[Display(Name = "Preço Pizza")]
		[Required(ErrorMessage = "Preço Obrigatório ")]
		public double PrecoPizza { get; set; }

		[Display(Name = "Status Pizza")]
		[Required(ErrorMessage = "Status Obrigatório ")]
		public string StatusPizza { get; set; }

		public DateTime DataPizza { get; set; } 

		public string GuidPizza { get; set; }

		public string GuidPedido { get; set; }
		
		#endregion
	}
}