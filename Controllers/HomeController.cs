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
			List<Reviews> AllReviews = _context.Reviews.ToList();

			return View();
        }
		[HttpGet]
		[Route("reviews")]
		public IActionResult Reviews()
		{
			return View();
		}

		[HttpPost]
		[Route("AddAReview")]
		public IActionResult AddAReview()
		{
            //Do some stuff...

			return RedirectToAction("Index");
		}
	}
}
