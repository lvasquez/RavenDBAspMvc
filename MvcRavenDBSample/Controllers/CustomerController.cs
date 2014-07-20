using MvcRavenDBSample.Data.Repository;
using MvcRavenDBSample.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcRavenDBSample.Controllers
{
    public class CustomerController : Controller
    {
        readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        // GET: Customer
        public ActionResult Index()
        {
            var list = this._customerService.GetCustomers().ToList();
            return View(list);
        }

        public ActionResult Details(int id)
        {
            var customer = this._customerService.Read(id);
            return View(customer);
        }

        public ActionResult Create()
        {
            return View("Create", new Customer());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                this._customerService.Create(customer);
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        public ActionResult Edit(int id)
        {
            var customer = this._customerService.Read(id);

            if (customer == null)
                return HttpNotFound();
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                this._customerService.Update(customer);
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        public ActionResult Delete(int id = 0)
        {
            var customer = this._customerService.Read(id);

            if (customer == null)
                return HttpNotFound();
            return View(customer);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            this._customerService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}