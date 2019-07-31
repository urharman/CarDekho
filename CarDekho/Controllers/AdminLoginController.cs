using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarDekho.Models;
using System.Data;
using System.Data.SqlClient;
namespace CarDekho.Controllers
{
    public class AdminLoginController : Controller
    {
        // GET: AdminLogin
        public ActionResult AdminLogin()
        {
            return View();
        }

        //this method is used to validte the user name or password of the user after verfiying the both the control will  transfer to another page 
        public ActionResult Login(AdminLogin log)
        {

            AdminLogin obj_Login = new AdminLogin();
            String query = "select * from AdminLogin where UserName='" + log.UserName + "' and UserPassword='" + log.UserPassword + "'";
            DataTable tbl = new DataTable();
            tbl = obj_Login.Login(query);

            if (tbl.Rows.Count > 0)
            {
                return View("Dashboard");
            }
            else
            {
                return View("Invalid");
            }
        }
    }
}