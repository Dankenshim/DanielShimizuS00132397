using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using s00132397DanielShimizu.Models;
using System.Net;
using System.Diagnostics;

namespace s00132397DanielShimizu.Controllers
{
    public class HomeController : Controller
    {

        FilmDb db = new FilmDb();
        public ActionResult Index()
        {
            ViewBag.PageTitle = "List of Films (Total No. of Films " + db.Films.Count() + ")";
            IQueryable<Film> films = db.Films;
            
            return View(films.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            //ViewBag.GenreList = 
            return View();
        }
   
        [HttpPost]
        public ActionResult Create(Film incomingFilm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var db = new FilmDb())
                    {
                        db.Films.Add(incomingFilm);
                        db.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var q = db.Films.Find(id);
            if (q == null) 
            {
                Debug.WriteLine("Record not found");
                ViewBag.PageTitle = String.Format("Sorry, record {0} not found.", id);
                
            }
            else
            {
                ViewBag.PageTitle = "Details of " + q.Title + " (" + ((q.Actors.Count == 0) ? "None" : q.Actors.Count.ToString()) + ')';
                ViewBag.SexStatsMale = q.Actors.Count(chld => chld.Sex == Sex.Male);
                ViewBag.SexStatsFemale = q.Actors.Count(chld => chld.Sex == Sex.Female);
            }

            return View(q);
        }
        public PartialViewResult ActorsById(int id)
        {
            var film = db.Films.Find(id);
            @ViewBag.filmId = id;
            @ViewBag.filmName = film.Title;
            return PartialView("_ActorsInFilm", film.Actors);
        }
        
       

       
    }
}
