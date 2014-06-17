using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesteNested2.Models;

namespace TesteNested2.Controllers
{
  public class EmployeeController : Controller
  {
    private EntidadesTesteNestedBD db = new EntidadesTesteNestedBD();

    //
    // GET: /Employee/

    public ActionResult Index()
    {
      return View(db.Employee.ToList());
    }

    //
    // GET: /Employee/Details/5

    public ActionResult Details(long id = 0)
    {
      Employee employee = db.Employee.Find(id);
      if (employee == null)
      {
        return HttpNotFound();
      }
      return View(employee);
    }

    //
    // GET: /Employee/Create

    public ActionResult Create()
    {
      Employee employee = new Employee();
      employee.CreatePhoneNumber(2);
      return View(employee);
    }

    //
    // POST: /Employee/Create

    [HttpPost]
    public ActionResult Create(Employee employee)
    {
      if (ModelState.IsValid)
      {
        db.Employee.Add(employee);
        db.SaveChanges();
        return RedirectToAction("Index");
      }

      return View(employee);
    }

    //
    // GET: /Employee/Edit/5

    public ActionResult Edit(long id = 0)
    {
      Employee employee = db.Employee.Find(id);
      if (employee == null)
      {
        return HttpNotFound();
      }
      return View(employee);
    }

    //
    // POST: /Employee/Edit/5

    [HttpPost]
    public ActionResult Edit(Employee employee)
    {
      if (ModelState.IsValid)
      {
        db.Entry(employee).State = EntityState.Modified;
        db.SaveChanges();
        return RedirectToAction("Index");
      }
      return View(employee);
    }

    //
    // GET: /Employee/Delete/5

    public ActionResult Delete(long id = 0)
    {
      Employee employee = db.Employee.Find(id);
      if (employee == null)
      {
        return HttpNotFound();
      }
      return View(employee);
    }

    //
    // POST: /Employee/Delete/5

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(long id)
    {
      Employee employee = db.Employee.Find(id);
      db.Employee.Remove(employee);
      db.SaveChanges();
      return RedirectToAction("Index");
    }

    public PartialViewResult DeletePhone(long id)
    {
      Phone phone = db.Phone.Find(id);
      if (phone != null)
      {
        db.Phone.Remove(phone);
        db.SaveChanges();
      }
      return PartialView();
    }
    protected override void Dispose(bool disposing)
    {
      db.Dispose();
      base.Dispose(disposing);
    }
  }
}