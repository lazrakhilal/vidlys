using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vidlys.Models;
using vidlys.ViewModels;

namespace vidlys.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random ()
        {
            var movie = new Movie() {Name = "Harry Potter and the philosopher stone" };
            //ViewData["Movie"] = movie;
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1"},
                new Customer { Name = "Customer 2"}
            };
            var viewModel = new RandomMovieViewModel {
                Movie = movie,
                Customers = customers
            };
            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            return Content("Id=" + id);
        }

        // movies
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;
            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";
            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }

        [Route("Movies/released/{year}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByReleasedDate(int year, int month)
        {
            return Content( year + "/" + month);
        }

    }
}