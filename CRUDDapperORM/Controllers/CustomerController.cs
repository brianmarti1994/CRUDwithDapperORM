using CRUDDapperORM.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDDapperORM.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            List<Customers> lstCustomers = new List<Customers>();
            lstCustomers = DapperORM.ReturnList<Customers>("spGetCustomers", null).ToList();
            return View(lstCustomers);
        }

        [HttpGet]
        public ActionResult AddOrEdit(int id=0)
        {
            if (id == 0)
            {
                return View();
            }
            else
            { 
                DynamicParameters param = new DynamicParameters();
                param.Add("@CustomerId", id);
                return View(DapperORM.ReturnList<Customers>("spGetCustomerById", param).FirstOrDefault<Customers>());
            }

        }

        [HttpPost]
        public ActionResult AddOrEdit(Customers objCustomers)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@CustomerId", objCustomers.CustomerId);
            param.Add("@CustomerName", objCustomers.CustomerName);
            param.Add("@CustomerEmail", objCustomers.CustomerEmail);
            param.Add("@CustomerPhone", objCustomers.CustomerPhone);

            DapperORM.ExecuteWithoutReturn("spAddOrEditCustomer", param);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id = 0)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@CustomerId", id);
            DapperORM.ExecuteWithoutReturn("spDeleteCustomer", param);
            return RedirectToAction("Index");
        }
        }
}
   
