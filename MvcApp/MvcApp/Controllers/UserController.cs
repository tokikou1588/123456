﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading;

namespace MvcApp.Controllers
{
    public partial class UserController : Controller
    {
        public  static List<Contact> contacts1 = new List<Contact>
        {
            new Contact{Id = "001", FirstName = "San", LastName = "Zhang", EmailAddress = "zhangsan@gmail.com", PhoneNo="123"},
            new Contact{Id = "002", FirstName = "Si", LastName = "Li", EmailAddress = "zhangsan@gmail.com", PhoneNo="456"}
        };

        public ActionResult Index1()
        {
            return View();
        }

        public ActionResult GetContacts1()
        {
            Thread.Sleep(5000);
            return View("ContactList",contacts);
        }
    }
}
