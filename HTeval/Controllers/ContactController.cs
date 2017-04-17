using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HTeval.Models;

namespace HTeval.Controllers
{
    [Authorize]
    public class ContactController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Contact List // Index
        public async Task<ActionResult> List()
        {
            return View(await db.Contacts.ToListAsync());
        }

        // GET: ContactModels/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactModel contactModel = await db.Contacts.FindAsync(id);
            if (contactModel == null)
            {
                return HttpNotFound();
            }
            return View(contactModel);
        }

        // GET: Contact/Search
        public ActionResult Search()
        {
            return View(new ContactSearchModel());
        }

        // POST: ContactModels/Search
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Search([Bind(Include = "FirstNameParameter,LastNameParameter")] ContactSearchModel csm)
        {
            if (ModelState.IsValid)
            {
                csm.SearchResults = await db.Database.SqlQuery<ContactModel>("EXECUTE ContactSearch {0}, {1}", csm.FirstNameParameter, csm.LastNameParameter ).ToListAsync();
            }

            return View(csm);
        }

        // GET: ContactModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContactModels/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,FirstName,LastName,EmailAddress,BirthDate,NumberOfComputers")] ContactModel contactModel)
        {
            if (ModelState.IsValid)
            {
                db.Contacts.Add(contactModel);
                await db.SaveChangesAsync();
                return RedirectToAction("List");
            }

            return View(contactModel);
        }

        // GET: ContactModels/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactModel contactModel = await db.Contacts.FindAsync(id);
            if (contactModel == null)
            {
                return HttpNotFound();
            }
            return View(contactModel);
        }

        // POST: ContactModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,FirstName,LastName,EmailAddress,BirthDate,NumberOfComputers")] ContactModel contactModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contactModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("List");
            }
            return View(contactModel);
        }

        // GET: ContactModels/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactModel contactModel = await db.Contacts.FindAsync(id);
            if (contactModel == null)
            {
                return HttpNotFound();
            }
            db.Contacts.Remove(contactModel);
            await db.SaveChangesAsync();
            return RedirectToAction("List");
        }

        // POST: ContactModels/Delete/5 // not used
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ContactModel contactModel = await db.Contacts.FindAsync(id);
            db.Contacts.Remove(contactModel);
            await db.SaveChangesAsync();
            return RedirectToAction("List");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
