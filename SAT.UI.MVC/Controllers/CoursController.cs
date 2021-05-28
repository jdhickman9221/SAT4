using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SAT.DATA.EF;
using SAT.UI.MVC.Utilitites;

namespace SAT.UI.MVC.Controllers
{

    public class CoursController : Controller
    {
        private SATDBEntities db = new SATDBEntities();

        // GET: Cours

        public ActionResult Index()
        {
            return View(db.Courses.ToList());
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Active()
        {
            var active = db.Courses.Where(x => x.IsActive == true).ToList();
            return View(active);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult NotActive()
        {
            var notActive = db.Courses.Where(x => x.IsActive == false).ToList();
            return View(notActive);
        }


        // GET: Cours/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cours cours = db.Courses.Find(id);
            if (cours == null)
            {
                return HttpNotFound();
            }
            return View(cours);
        }

        // GET: Cours/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cours/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CourseId,CourseName,CourseDescription,CreditHours,Curriculum,Notes,IsActive,PhotoURL")] Cours cours, HttpPostedFileBase coursPhoto)
        {
            string file = "noImage";
            if (coursPhoto != null)
            {
                file = coursPhoto.FileName;

                string ext = file.Substring(file.LastIndexOf("."));
                string[] goodExts = { ".jpg", ".jpeg", ".png", ".gif" };

                if (goodExts.Contains(ext.ToLower()) && coursPhoto.ContentLength <= 4194304)
                {
                    file = Guid.NewGuid() + ext;


                    string savePath = Server.MapPath("~/Content/imgStore/");
                    Image convertedImage = Image.FromStream(coursPhoto.InputStream);
                    int maxImageSize = 500;
                    int maxThumbSize = 100;

                    ImageServices.ResizeImage(savePath, file, convertedImage, maxImageSize, maxThumbSize);
                }

            }

            cours.PhotoURL = file;


            if (ModelState.IsValid)
            {
                db.Courses.Add(cours);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cours);
        }

        // GET: Cours/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cours cours = db.Courses.Find(id);
            if (cours == null)
            {
                return HttpNotFound();
            }
            return View(cours);
        }

        // POST: Cours/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CourseId,CourseName,CourseDescription,CreditHours,Curriculum,Notes,IsActive,PhotoURL")] Cours cours, HttpPostedFileBase coursPhoto)
        {
            if (ModelState.IsValid)
            {
                string file = "noImage.png";

                if (coursPhoto != null)
                {
                    file = coursPhoto.FileName;
                    string ext = file.Substring(file.LastIndexOf("."));
                    string[] goodExts = { ".jpeg", ".jpg", ".png", ".gif", ".jfif" };
                    if (goodExts.Contains(ext.ToLower()) && coursPhoto.ContentLength <= 4194304)
                    {
                        file = Guid.NewGuid() + ext;

                        string savePath = Server.MapPath("~/Content/imgStore");
                        Image convertedImage = Image.FromStream(coursPhoto.InputStream);
                        int maxImageSize = 500;
                        int maxThumbSize = 100;
                        ImageServices.ResizeImage(savePath, file, convertedImage, maxImageSize, maxThumbSize);

                        if (cours.PhotoURL != null && cours.PhotoURL != "noImage.png")
                        {
                            string path = Server.MapPath("~/Content/imgStore");
                            ImageServices.Delete(path, cours.PhotoURL);
                        }

                    }

                }
                cours.PhotoURL = file;

                db.Entry(cours).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           
            return View(cours);
        }

        // GET: Cours/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cours cours = db.Courses.Find(id);
            if (cours == null)
            {
                return HttpNotFound();
            }
            return View(cours);
        }

        // POST: Cours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cours cours = db.Courses.Find(id);

            string path = Server.MapPath("~/Content/imgStore/");
            ImageServices.Delete(path, cours.PhotoURL);

            db.Courses.Remove(cours);
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
    }
}
