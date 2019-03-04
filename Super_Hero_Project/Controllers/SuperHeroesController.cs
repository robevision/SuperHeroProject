using Super_Hero_Project.Models;
using System;
using System.Collections.Generic;
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
            //IEnumerable<SuperHeroes> superHeroes = new List<SuperHeroes>();
            return View(db.SuperHeroes.ToList());
        }

        // GET: SuperHeroes/Details/5
        public ActionResult Details(int id)
        {//singular
            //IEnumerable<SuperHeroes> superHeroes = new List<SuperHeroes>();
            return View(db.SuperHeroes.ToList());
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
        public ActionResult Create([Bind(Include = "Name,AlterEgo,PrimaryAbility,AlternativeAbility,CatchPhrase")] SuperHeroes superHeroes)
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
            return View();
        }

        // POST: SuperHeroes/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, [Bind(Include = "Name,AlterEgo,PrimaryAbility,AlternativeAbility,CatchPhrase")] SuperHeroes superHeroes)
        {
            try
            {
                db.SuperHeroes.Where(s => s.ID == id).ToList();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(superHeroes);
            }
        }

        // GET: SuperHeroes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SuperHeroes/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, SuperHeroesController collection)
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
