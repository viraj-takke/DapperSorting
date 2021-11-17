using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_CRUD.Models;

namespace MVC_CRUD.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        private CustomerRepository repository;
        public CustomerController()
        {
            repository = new CustomerRepository();
        }
        public ActionResult Index(RequestModel request)
        {
            if (request.OrderBy == null)
            {
                request = new RequestModel
                {
                    Search = request.Search,
                    OrderBy = "name",
                    IsDescending = false
                };
            }
            ViewBag.Request = request;
            return View(repository.GetAll(request));
        }
        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            return View(repository.Get(id));
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(Customer customer, bool editAfterSaving = false)
        {
            if (ModelState.IsValid)
            {
                var lastInsertedId = repository.Create(customer);
                if (lastInsertedId > 0)
                {
                    TempData["Message"] = "Record added successfully";
                }
                else
                {
                    TempData["Error"] = "Failed to add record";
                }
                if (editAfterSaving)
                {
                    return RedirectToAction("Edit", new { Id = lastInsertedId });
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
        // GET: Customer/Edit/5
        public ActionResult Edit(int Id)
        {
            return View(repository.Get(Id));
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                var recordAffected = repository.Update(customer);
                if (recordAffected > 0)
                {
                    TempData["Message"] = "Record updated successfully";
                }
                else
                {
                    TempData["Error"] = "Failed to update record";
                }
                return RedirectToAction("Index");
            }
            return View();
        }
        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View(repository.Get(id));
        }

        // POST: Vegetable/Delete/5
        [HttpPost]
        public ActionResult Delete(Customer customer)
        {
            var recordAffected = repository.Delete(customer.Id);
            if (recordAffected > 0)
            {
                TempData["Message"] = "Record deleted successfully";
            }
            else
            {
                TempData["Error"] = "Failed to delete record";
            }
            return RedirectToAction("Index");
        }
    }
}