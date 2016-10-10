using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab24.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        // GET: Customer/Details/5
        public ActionResult List()
        {
            NorthwindEntities dbcontext = new NorthwindEntities();
            List<Customer> customers = dbcontext.Customers.ToList();
            return View(customers);
        }

        // GET: Customer/Add and Create
        //public ActionResult Add()
        //{
        //make a view to add to database
        //Customer cust = new Customer();

        //cust.CompanyName = Request.Form["Company Name"];
        //cust.ContactName = Request.Form["Contact Name"];
        //cust.ContactTitle = Request.Form["Contact Title"];
        //cust.Address = Request.Form["Address"];
        //cust.City = Request.Form["City"];
        //cust.Region = Request.Form["Region"];
        //cust.PostalCode = Request.Form["Postal Code"];
        //cust.Country = Request.Form["Country"];
        //cust.Phone = Request.Form["Phone"];
        //cust.Fax = Request.Form["Fax"];


        //NorthwindEntities dbcontext = new NorthwindEntities();
        ////db.savechanges
        //    //return View();
        //}

        // POST: Customer/Create

        public ActionResult Add()
        {

            return View();

        }
        [HttpPost]
        public ActionResult Add(Customer customer)
        {
            try
            {
              
                NorthwindEntities dbcontext = new NorthwindEntities();
                Customer customers = dbcontext.Customers.Add(customer);
                dbcontext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View();
            }
        }
        
        // GET: Customer/Edit/5
        public ActionResult Edit(string id)
        {
            // if no id, send them to the list
            if (string.IsNullOrWhiteSpace(id))
            {
                return RedirectToAction("List");
            }

            NorthwindEntities dbcontext = new NorthwindEntities();
            Customer customer = dbcontext.Customers.First(c => c.CustomerID == id);
            return View(customer);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, Customer customer)
        {
            try
            {
                NorthwindEntities dbcontext = new NorthwindEntities();
                Customer dbCustomer = dbcontext.Customers.First(c => c.CustomerID == id);
                dbCustomer.CompanyName = customer.CompanyName;
                dbCustomer.ContactName = customer.ContactName;
                dbCustomer.Address = customer.Address;
                dbCustomer.City = customer.City;
                dbCustomer.ContactTitle = customer.ContactTitle;
                dbCustomer.Country = customer.Country;
                dbCustomer.Fax = customer.Fax;
                dbCustomer.Phone = customer.Phone;
                dbCustomer.PostalCode = customer.PostalCode;
                dbCustomer.Region = customer.Region;

                dbcontext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(string id)
        {
            // if no id, send them to the list
            if (string.IsNullOrWhiteSpace(id))
            {
                return RedirectToAction("List");
            }

            NorthwindEntities dbcontext = new NorthwindEntities();
            Customer customer = dbcontext.Customers.First(c => c.CustomerID == id);
            dbcontext.Customers.Remove(customer);
            try
            {
                dbcontext.Orders.Find();
            }
            catch { 
            dbcontext.SaveChanges();
            return RedirectToAction("List");
            }
        }

        
    }
}
