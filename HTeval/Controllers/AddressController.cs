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
    public class AddressController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Address
        public async Task<ActionResult> Index()
        {
            return View(await db.Addresses.ToListAsync());
        }

        // GET: Address/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddressModel addressModel = await db.Addresses.FindAsync(id);
            if (addressModel == null)
            {
                return HttpNotFound();
            }
            return View(addressModel);
        }

        // GET: Address/Create
        public ActionResult Create(int cid)
        {            
            ViewData["ParentContact"] = db.Contacts.Find(cid);
            return View();
        }

        // POST: Address/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,AddressType,AddressLine1,AddressLine2,City,StateCode,Zip,ContactModel_ID")] AddressModel addressModel)
        {
            if (ModelState.IsValid)
            {
                ContactModel ParentContact = db.Contacts.Find(addressModel.ContactModel_ID);
                //db.Addresses.Add(addressModel);
                ParentContact.Addresses.Add(addressModel);
                db.Entry(ParentContact).State = EntityState.Modified;
                await db.SaveChangesAsync();
                //return RedirectToAction("List", "Contact");
                return RedirectToAction("Details","Contact",new { id = ParentContact.ID });
            }

            return View(addressModel);
        }

        // GET: Address/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddressModel addressModel = await db.Addresses.FindAsync(id);
            if (addressModel == null)
            {
                return HttpNotFound();
            }
            ViewData["ParentContact"] = db.Contacts.Find(addressModel.ContactModel_ID);
            return View(addressModel);
        }

        // POST: Address/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,AddressType,AddressLine1,AddressLine2,City,StateCode,Zip,ContactModel_ID")] AddressModel addressModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(addressModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Details", "Contact", new { id = addressModel.ContactModel_ID });
            }
            return View(addressModel);
        }

        // GET: Address/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddressModel addressModel = await db.Addresses.FindAsync(id);
            if (addressModel == null)
            {
                return HttpNotFound();
            }
            int ParentContactID = addressModel.ContactModel_ID;
            db.Addresses.Remove(addressModel);
            await db.SaveChangesAsync();
            return RedirectToAction("Details", "Contact", new { id = ParentContactID });
        }

        // POST: Address/Delete/5 // Not used
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            AddressModel addressModel = await db.Addresses.FindAsync(id);
            db.Addresses.Remove(addressModel);
            await db.SaveChangesAsync();
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
    }
}
