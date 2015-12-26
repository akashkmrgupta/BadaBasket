using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer.EntityModel;

namespace BadaBasket.Controllers
{
    public class AdminController : Controller
    {
        private BadaBasketEntities db = new BadaBasketEntities();

        //
        // GET: /Admin/

        public ActionResult Index()
        {
            return View(db.Items.ToList());
        }

        //
        // GET: /Admin/Details/5

        public ActionResult Details(int id = 0)
        {
            Item item = db.Items.Single(i => i.ItemID == id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        //
        // GET: /Admin/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/Create

        [HttpPost]
        public ActionResult Create(Item item)
        {
            if (ModelState.IsValid)
            {
                db.Items.AddObject(item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(item);
        }

        //
        // GET: /Admin/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Item item = db.Items.Single(i => i.ItemID == id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        //
        // POST: /Admin/Edit/5

        [HttpPost]
        public ActionResult Edit(Item item)
        {
            if (ModelState.IsValid)
            {
                db.Items.Attach(item);
                db.ObjectStateManager.ChangeObjectState(item, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(item);
        }

        //
        // GET: /Admin/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Item item = db.Items.Single(i => i.ItemID == id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        //
        // POST: /Admin/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Item item = db.Items.Single(i => i.ItemID == id);
            db.Items.DeleteObject(item);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}