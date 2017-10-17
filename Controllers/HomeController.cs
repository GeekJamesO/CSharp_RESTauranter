using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using RESTauranter.Models;

namespace RESTauranter.Controllers
{
	public class HomeController : Controller
	{
		private RESTauranterContext _context;

		public HomeController(RESTauranterContext context)
		{
			_context = context;
		}

		// GET: /Home/
		[HttpGet]
		[Route("")]
		public IActionResult Index()
		{
			ViewBag.errors = "";
			return View();
		}
		[HttpGet]
		[Route("reviews")]
		public IActionResult Reviews()
		{
			List<Reviews> AllReviews = _context.Reviews.ToList();
			ViewBag.AllReviews = AllReviews;
			return View();
		}

		[HttpPost]
		[Route("AddAReview")]
		public IActionResult AddAReview(Reviews newReview)
		{
			
			if (TryValidateModel(newReview))
			{
				if (newReview.isValidDate())
				{
					_context.Add(newReview);
					_context.SaveChanges();
					return RedirectToAction("Reviews");
				}
				else
				{
					//Date is too large error..
					string[] err1 = { "Date cannot be in the future."};
					ViewBag.errors = err1;
					return RedirectToAction("Index");
				}
			}
			else
			{
				ViewBag.errors = ModelState.Values;
				// return RedirectToAction("Index");
				return View("Index");
			}

		}
	}
}
