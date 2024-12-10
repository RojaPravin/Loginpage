using Loginpage.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Loginpage.Controllers
{
    public class LoginController : Controller
    {
        string myconnection = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        // GET: Login/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Login/Create
        public ActionResult Create()
        {
           
            return View();
        }

        // POST: Login/Create
        [HttpPost]
        public ActionResult Create(Login obj)
        {
            using (SqlConnection con = new SqlConnection(myconnection))
            {
                string query = "sp_login '" + obj.Email + "','" + obj.Password + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.Read())
                {
                    obj = new Login() { 
                        Email = reader["Email"].ToString(),
                        Password = reader["Password"].ToString(),
                    };
                    ViewBag.Msg = "Login Success";
                   
                }
                else
                {
                    ViewBag.Msg = "Login failed";

                }
                con.Close();
                return View();

            }

        }

        // GET: Login/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Login/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Login/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Login/Delete/5
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
    }
}
