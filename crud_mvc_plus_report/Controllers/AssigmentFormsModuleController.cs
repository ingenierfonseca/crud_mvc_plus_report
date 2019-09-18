using crud_mvc_plus_report.Models;
using DataAccess;
using Domain.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace crud_mvc_plus_report.Controllers
{
    public class AssigmentFormsModuleController : Controller
    {
        ApplicationContext db = new ApplicationContext();
        
        // GET: AssigmentFormsModule
        public ActionResult Index()
        {


            //Inner Join
            //var query = from a in db.Modules
            //            join b in db.AssigmentsFormsModule on a.ModuleId equals b.ModuleId
            //            join c in db.Forms on b.FormId equals c.FormId
            //            select new ModuleForms()
            //            {
            //                NameForm = c.Name,
            //                NameModule = a.Name
            //            };

            //Left Join de Modules sin Forms
            var query = from a in db.Modules
                        join b in db.AssigmentsFormsModule on a.ModuleId equals b.ModuleId
                        into AsigModules
                        from b in AsigModules.DefaultIfEmpty()
                        join c in db.Forms on b.FormId equals c.FormId into AsigForm
                        from c in AsigForm.DefaultIfEmpty()
                        select new ModuleForms()
                        {
                            AssigmentId = b == null ? 0 : b.AssigmentId,
                            FormId = b == null ? 0 : b.FormId,
                            NameForm = b == null ? "No Form": c.Name,
                            NameModule = a.Name,
                            ModuleId = a.ModuleId
                        }
                        ;


            return View(query);
        }

        // GET: AssigmentFormsModule/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AssigmentFormsModule/Create
        public ActionResult Create()
        {
            ViewBag.Modules = GetModuleDropDown();
            ViewBag.Forms = GetFormDropDown();

            return View();
        }

        // POST: AssigmentFormsModule/Create
        [HttpPost]
        public ActionResult Create(AssigmentFormsModule moduleForm)
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

        // GET: AssigmentFormsModule/Edit/5
        public ActionResult Edit(int id)
        {
            //ModuleForms query = (from a in db.AssigmentsFormsModule
            //                    where a.AssigmentId.Equals(id)
            //                    select new ModuleForms()
            //                    {
            //                        AssigmentId = a.AssigmentId,
            //                        ModuleId = a.ModuleId,
            //                        FormId = a.FormId
            //                    }).FirstOrDefault();

            var query = db.AssigmentsFormsModule.Find(id);

            ViewBag.Modules = GetModuleDropDown();
            ViewBag.Forms = GetFormDropDown();

            return View(query);
        }

        // POST: AssigmentFormsModule/Edit/5
        [HttpPost]
        public ActionResult Edit(AssigmentFormsModule moduleForm)
        {
            try
            {
                // TODO: Add update logic here
                if (!ModelState.IsValid)
                {
                    return View();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AssigmentFormsModule/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AssigmentFormsModule/Delete/5
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

        public List<SelectListItem> GetModuleDropDown()
        {
            var items = db.Modules.Select(
               c => new SelectListItem()
               {
                   Text = c.Name,
                   Value = c.ModuleId.ToString()
               }).ToList();
            return items;
        }

        public List<SelectListItem> GetFormDropDown()
        {
            var items = db.Forms.Select(
               c => new SelectListItem()
               {
                   Text = c.Name,
                   Value = c.FormId.ToString()
               }).ToList();
            return items;
        }
    }
}
