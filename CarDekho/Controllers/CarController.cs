using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarDekho.Models;
namespace CarDekho.Controllers
{
    public class CarController : Controller
    {
        // GET: Car
        dbcarDekhoEntities db = new dbcarDekhoEntities();
        public ActionResult car()
        {
            return View();
        }
        public ActionResult ViewCar()
        {
            return View(db.cars.ToList());
        }

        public ActionResult Delete(car pizzaID)
        {
            var d = db.cars.Where(x => x.id == pizzaID.id).FirstOrDefault();
            db.cars.Remove(d);
            db.SaveChanges();
            return RedirectToAction("ViewCar");
        }
        [HttpPost]
        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public ActionResult car(car image)
        {

            String fileName = Path.GetFileNameWithoutExtension(image.ImageFile.FileName);
            String extension = Path.GetExtension(image.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmfff") + extension;
            image.Photo = fileName;
            fileName = Path.Combine(Server.MapPath("~/carPhoto/"), fileName);
            image.ImageFile.SaveAs(fileName);
            using (dbcarDekhoEntities db = new dbcarDekhoEntities())
            {

                db.cars.Add(image);
                db.SaveChanges();
            }
            ModelState.Clear();
            return View();

        }
        // GET: Car/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Car/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Car/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Car/Edit/5
        public ActionResult Edit(int id)
        {
            var carToEdit = (from m in db.cars where m.id == id select m).First();
            return View(carToEdit);
        }

        // POST: Car/Edit/5
        [HttpPost]
        public ActionResult Edit(car carToEdit)
        {
            var orignalRecord = (from m in db.cars where m.id==carToEdit.id select m).First();
           /* String fileName = Path.GetFileNameWithoutExtension(image.ImageFile.FileName);
            String extension = Path.GetExtension(image.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmfff") + extension;
            image.Photo = fileName;
            fileName = Path.Combine(Server.MapPath("~/carPhoto/"), fileName);
           // image.ImageFile.SaveAs(fileName);
           */

            if (!ModelState.IsValid)
                return View(orignalRecord);
            db.Entry(orignalRecord).CurrentValues.SetValues(carToEdit);
            db.SaveChanges();
            return RedirectToAction("ViewCar");

        }

      
    }
}
