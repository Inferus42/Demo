using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.DAO;
using WebApplication2.Models;


namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        ShipDAO recordsDAO = new ShipDAO();
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View(recordsDAO.GetAllRecords());
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }
        //
        // POST: /Home/Create
        [AcceptVerbs(HttpVerbs.Post)]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Exclude = "ID")] Ship records)
        {
            try
            {
                records.Date = DateTime.Now;
                if (recordsDAO.AddRecord(records))
                    return RedirectToAction("Index");
                else
                    return View("Create");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { ErrorText = ex.Message });
            }
        }

        // GET: Home/Details/5
        [AcceptVerbs(HttpVerbs.Get)]
        [Authorize(Roles = "Admin, Visitor")]
        public ActionResult Details(int id)
        {
            ShipDAO r = new ShipDAO();
            return View(r.getById(id));
        }
        [AcceptVerbs(HttpVerbs.Post)]
        [Authorize(Roles = "Admin, Visitor")]

        public ActionResult Details()
        {
            return View();
        }



        // GET: Home/Edit/5
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            ShipDAO r = new ShipDAO();
            return View(r.getById(id));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(Ship record)
        {
            if (ModelState.IsValid)
            {
                record.Date = DateTime.Now;
                recordsDAO.EditRecord(record);
                return RedirectToAction("Index");
            }
            else
            {
                return View("Edit");
            }
        }

        // GET: Home/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            ShipDAO r = new ShipDAO();
            return View(r.getById(id));
        }

        // POST: Home/Delete/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                ShipDAO r = new ShipDAO();
                r.DeleteRecord(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { ErrorText = ex.Message });
            }
        }
        [HttpPost]
        public ActionResult Error(string s)
        {
            return View(s);
        }

    }
}
