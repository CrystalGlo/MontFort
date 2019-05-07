using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MontFort.Models;
using System.Windows;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MontFort.Controllers
{
    public class ResidentsController : Controller
    {
        public ResidenceDBContext db = new ResidenceDBContext();

        // GET: Residents
        public ActionResult Index(string firstName, string lastName)
        {
            var residents = from res in db.Residents.Include(r => r.Room)
                            select res;

            if (!String.IsNullOrEmpty(firstName))
            {
                residents = residents.Where(s => s.FirstName.StartsWith(firstName));
            }

            if(!string.IsNullOrEmpty(lastName))
            {
                residents = residents.Where(x => x.LastName.StartsWith(lastName));
            }
            
            return View(residents);
        }

        // GET: Residents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resident resident = db.Residents.Find(id);
            if (resident == null)
            {
                return HttpNotFound();
            }
            return View(resident);
        }

        // GET: Residents/Create
        public ActionResult Create()
        {
            ViewBag.RoomNbr = new SelectList(db.Rooms, "RoomNbr", "RoomNbr");
            return View();
        }

        // POST: Residents/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,LastName,BirthDate,Gender,FolderNbr,RoomNbr,InMotion,Place,Mandatary,FamilyMember")] Resident resident)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Residents.Add(resident);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("RoomNbr", "Cette chambre contient déjà un résident, veuillez choisir une autre.");
                    RedirectToAction("Index");
                }
               
            }
           
            ViewBag.RoomNbr = new SelectList(db.Rooms, "RoomNbr", "RoomNbr", resident.RoomNbr);
            ViewBag.Title = "la chambre est prise";
            return View(resident);
        }

        // GET: Residents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resident resident = db.Residents.Find(id);
            if (resident == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoomNbr = new SelectList(db.Rooms, "RoomNbr", "RoomNbr", resident.RoomNbr);
            return View(resident);
        }

        // POST: Residents/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName,BirthDate,Gender,FolderNbr,RoomNbr,InMotion,Place,Mandatary,FamilyMember")] Resident resident)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(resident).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("RoomNbr", "Cette chambre contient déjà un résident, veuillez choisir une autre.");
                RedirectToAction("Index");
            }

            ViewBag.RoomNbr = new SelectList(db.Rooms, "RoomNbr", "RoomNbr", resident.RoomNbr);
            return View(resident);
        }

        // GET: Residents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resident resident = db.Residents.Find(id);
            if (resident == null)
            {
                return HttpNotFound();
            }
            return View(resident);
        }

        // POST: Residents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Resident resident = db.Residents.Find(id);
            db.Residents.Remove(resident);
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

        /*public ActionResult ClearSearch()
        {
            System.Windows.Forms.WebBrowser webBrowser = new WebBrowser();
            HtmlDocument document = webBrowser.Document;
            document.GetElementById("firtname"). = "";
            
                return RedirectToAction("Index");
        }*/

        /*public JsonResult IsRoomAvailable(int roomNbr, int? ID)
        {
            var validateRoom = db.Residents.FirstOrDefault
                                (x => x.RoomNbr == roomNbr && x.ID != ID);
            if (validateRoom != null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }*/
    }
}
