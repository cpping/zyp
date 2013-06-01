using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieApp.Models;
using System.Linq;
using System.Collections.Generic;
using System.Web.Mvc.Ajax; 

namespace MovieApp.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        private MoviesDBEntities _db = new MoviesDBEntities(); 
        public ActionResult Index()
        {
            return View(_db.Movies.ToList());
        }

        //
        // GET: /Home/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Home/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Home/Create

        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
        [HttpPost]
        public ActionResult Create([Bind(Exclude="Id")] Movie movieToCreate)
    {
        if (!ModelState.IsValid)
            return View();
        _db.AddToMovies(movieToCreate);
        _db.SaveChanges();
        return RedirectToAction("Index");

    }
        //
        // GET: /Home/Edit/5
 
        public ActionResult Edit(int id)
        {
            var movieToEdit = (from m in _db.Movies
                               where m.Id == id
                               select m).First();
            return View(movieToEdit);
            if (!ModelState.IsValid)
            {
                return View(_db.Movies);
                //_db.ApplyPropertyChanges(_db.ToString(); movieToEdit);
                _db.SaveChanges();
            }
        }

        //
        // POST: /Home/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Home/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Home/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
