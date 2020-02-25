using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WhoLetDerHundOut.DAL;
using WhoLetDerHundOut.Models;

namespace WhoLetDerHundOut.Controllers
{
    public class DogController : Controller
    {
        private DogContext db = new DogContext();

        // GET: Dog
        public ActionResult Index()
        {
            //var dogs = db.Dogs.Include(d => d.Breeds);
            return View(db.Dogs.ToList());
        }

        // GET: Dog/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dog dog = db.Dogs.Find(id);
            if (dog == null)
            {
                return HttpNotFound();
            }
            return View(dog);
        }

        // GET: Dog/Create
        public ActionResult Create()
        {
            ViewBag.BreedId = new SelectList(db.Breeds, "BreedId", "BreedName");
            return View();
        }

        // POST: Dog/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DogId,UserId,nickName,Breed,BreedId")] Dog dog)
        {
            if (ModelState.IsValid)
            {
                db.Dogs.Add(dog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BreedId = new SelectList(db.Breeds, "BreedId", "BreedName", dog.BreedId);
            return View(dog);
        }

        // GET: Dog/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dog dog = db.Dogs.Find(id);
            if (dog == null)
            {
                return HttpNotFound();
            }
            ViewBag.BreedId = new SelectList(db.Breeds, "BreedId", "BreedName", dog.BreedId);
            return View(dog);
        }

        // POST: Dog/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DogId,UserId,nickName,Breed,BreedId")] Dog dog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BreedId = new SelectList(db.Breeds, "BreedId", "BreedName", dog.BreedId);
            return View(dog);
        }

        // GET: Dog/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dog dog = db.Dogs.Find(id);
            if (dog == null)
            {
                return HttpNotFound();
            }
            return View(dog);
        }

        // POST: Dog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dog dog = db.Dogs.Find(id);
            db.Dogs.Remove(dog);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Display()
        {
            return View(db.Dogs.ToList());
        }
    }
}
