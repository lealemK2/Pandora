using Pandora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Data.Entity;

namespace Pandora.Controllers
{
    public class RentalsController : Controller
    {
        private ApplicationDbContext _context;


        public RentalsController()
        {
            _context = new ApplicationDbContext();
        } 

        public ActionResult Index()
        {
            var rentals = _context.Rentals.Include(m => m.Movie).Include(m => m.Customer).ToList(); 
            return View(rentals);
        }
        // GET: Rental
        public ActionResult New()
        {
            return View();
        }

        public ActionResult ListMoviesOfCustomer(int customerd)
        {
            return View();
        }
        public ActionResult Delete(int Id)
        {
            var rental = _context.Rentals.Include(m => m.Movie).Single(c => c.Id == Id);

            if (rental == null)
                return HttpNotFound();

            var movieInDb=_context.Movies.Single(m => m.Id == rental.Movie.Id);
            movieInDb.NumberAvailable++;

            _context.Rentals.Remove(rental);
            _context.SaveChanges();
            return RedirectToAction("Index", "Rentals");
        }

    }
}