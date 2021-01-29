using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Security;
using WeddingStore.Models;

namespace WeddingStore.Controllers
{
    public class AccountController : Controller
    {
        SqlConnection sqlConnection = new SqlConnection();
        SqlCommand sqlCommand = new SqlCommand();
        SqlDataReader dataReader;

        void connectionString()
        {
            sqlConnection.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB; Database=WeddingStore; Integrated Security = SSPI;";
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Account account, string returnUrl)
        {
            connectionString();
            sqlConnection.Open();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "SELECT * FROM Login WHERE username='"+account.Name+"' and password='"+account.Password+"'";
            dataReader = sqlCommand.ExecuteReader();
            if (ModelState.IsValid)
            {
                if (dataReader.HasRows)
                {
                    FormsAuthentication.SetAuthCookie(account.Name, true);
                    FormsAuthentication.RedirectFromLoginPage(account.Name, true);
                    sqlConnection.Close();
                    return Redirect(returnUrl ?? Url.Action("AdminConsole", "Admin"));
                }
                else
                {
                    sqlConnection.Close();
                    ModelState.AddModelError("LoginError", "Podany login lub hasło są nieprawidłowe.");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
    }
}