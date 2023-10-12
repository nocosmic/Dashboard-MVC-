using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dashboard_MVC_;
using System.Data;


namespace Dashboard_MVC_.Controllers
{
    public class AccountController : Controller
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {

            return View();
        }
        void connectionString()
        {
            conn.ConnectionString = "Data Source=SAK-LAPBDC599\\LOGIN;Initial Catalog=Employee;Integrated Security=True";
        }

        [HttpPost]
        public ActionResult Verify(Account acc)
        {
            connectionString();
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "select * from LOGIN where Username ='" + acc.Email +"' and Password ='" + acc.Password + "'";
            dr = cmd.ExecuteReader();
            if(dr.Read( ))
            {
                conn.Close();
                return View("Dashboard");
            }
            else
            {
                conn.Close();
                return View("Dashboard");
            }
           
        }
    }
}