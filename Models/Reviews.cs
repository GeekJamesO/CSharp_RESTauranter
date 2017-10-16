using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RESTauranter.Models
{
	public class Reviews : BaseEntity
	{
		public int id { get; set; }

		[Required]
		public string ReviewerName { get; set; }

		[Required]
		public string RestaurantName { get; set; }

		[Required]
		[MinLength(5)]
		[MaxLength(100)]
		public string ReviewText {get;set;}

		[Required]
		public DateTime DateOfVisit { get; set; }

		[Required]
		[Range(1,5)]
		public int Stars { get; set; }
	}
}
