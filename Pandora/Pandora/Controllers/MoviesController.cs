using Pandora.Models;
using Pandora.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Pandora.Migrations;
using System.IO;

namespace Pandora.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();
            if (User.IsInRole(RoleName.CanManageMovies))
                return View("List",movies);
            return View("ReadOnlyList",movies);
        }

        [Authorize(Roles = RoleName.CanManageMovies)] 
        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel()
            {
                Genres = genres
            };
            return View("MovieForm", viewModel);
        }


        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel(movie)
            {
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", viewModel);
        }
        
         
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };
                return View("MovieForm", viewModel);
            }
            if (movie.Id == 0)
            {
                if (movie.ImageFile != null) 
                {
                    string fileName = Path.GetFileNameWithoutExtension(movie.ImageFile.FileName);
                    string extension = Path.GetExtension(movie.ImageFile.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    movie.ImagePath = "~/content/uploadedimages/"+fileName;
                    fileName = Path.Combine(Server.MapPath("~/content/uploadedimages/"), fileName);
                    movie.ImageFile.SaveAs(fileName);
                    ModelState.Clear();
                }
                else
                {
                    movie.ImagePath = "~/content/uploadedimages/noimage5.png";
                }

                movie.DateAdded = DateTime.Now;
                movie.NumberAvailable = movie.NumberInStock;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                if (movie.ImageFile!=null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(movie.ImageFile.FileName);
                    string extension = Path.GetExtension(movie.ImageFile.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    movie.ImagePath = "~/content/uploadedimages/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/content/uploadedimages/"), fileName);
                    movie.ImageFile.SaveAs(fileName);
                    movieInDb.ImagePath = movie.ImagePath;
                    movieInDb.ImageFile = movie.ImageFile;
                    ModelState.Clear();
                }
            }
            _context.SaveChanges();  
            return RedirectToAction("Index", "Movies");
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Delete(int Id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == Id);

            if (movie == null)
                return HttpNotFound();

            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

    }
}