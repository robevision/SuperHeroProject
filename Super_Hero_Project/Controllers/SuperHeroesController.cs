using Super_Hero_Project.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Super_Hero_Project.Controllers
{
    public class SuperHeroesController : Controller
    {
        ApplicationDbContext db;
        public SuperHeroesController()
        {
            db = new ApplicationDbContext();
        }
        // GET: SuperHeroes
        [HttpGet]
        public ActionResult Index()
        {//multiple
            return View(db.SuperHeroes.ToList());
        }

        // GET: SuperHeroes/Details/5
        [HttpGet]
        public ActionResult Details(int id)
        {//singular
            try
            {
                return View(db.SuperHeroes.Where(s=>s.ID==id).Single());
            }
            catch
            {
                return View(db.SuperHeroes);
            }         
        }

        // GET: SuperHeroes/Create
        public ActionResult Create()
        {
            ViewBag.ID = new SelectList(db.SuperHeroes, "Id", "Name");
            return View();
        }

        // POST: SuperHeroes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,AlterEgo,PrimaryAbility,AlternativeAbility,CatchPhrase")] SuperHeroes superHeroes)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.SuperHeroes.Add(superHeroes);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.PersonId = new SelectList(db.SuperHeroes, "Id", "Name", superHeroes.ID);
                return View(superHeroes);
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperHeroes/Edit/5
        public ActionResult Edit(int id)
        {
            
            return View(db.SuperHeroes.Where(s => s.ID == id).Single());
        }

        // POST: SuperHeroes/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, [Bind(Include = "ID,Name,AlterEgo,PrimaryAbility,AlternativeAbility,CatchPhrase")] SuperHeroes superHero)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //var updatedSuperHeroes = db.SuperHeroes.Where(s=> s.ID == id).Select(s=>s).Single();

                    //updatedSuperHeroes = superHero;
                    db.Entry(superHero).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(superHero); 
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperHeroes/Delete/5
        public ActionResult Delete(int id)
        {
            return View(db.SuperHeroes.Where(s => s.ID == id).Single());
        }

        // POST: SuperHeroes/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, SuperHeroes superHero)
        {
            //try
            //{
                db.SuperHeroes.Remove(superHero);
                //db.Entry(superHero).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View();
            //}
        }
    }
}
