using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainApp.Models;
using System.Data.SqlClient;
using TrainApp.Models;

namespace TrainApp.Controllers
{
    public class LoginAccountController : Controller
    {


        //SqlConnection con = new SqlConnection();
        //SqlCommand com = new SqlCommand();
        //SqlDataReader dr;

        trainDBEntities db = new trainDBEntities();
        
        public ActionResult Index()
        {
            return View(db.LoginTables.ToList());
        }

        public ActionResult Signup()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }



        // GET: LoginAccount
        [HttpPost]
        public ActionResult Login(LoginTable userInfo)
        {
            var loginCheck = db.LoginTables.Where(x => x.Username.Equals(userInfo.Username) && x.Password.Equals(userInfo.Password)).FirstOrDefault();
            if (loginCheck != null)
            {
                Session["UserIdSession"] = userInfo.UserID.ToString();
                Session["UserNameSession"] = userInfo.Username.ToString();

                return RedirectToAction("Index", "Home");


            }
            else
            {
                TempData["LoginInfoMessage"] = "Incorrect User Name or Password";

            }

            return View();

            //return RedirectToAction("GoodLogin", "LoginAccount");


        }


        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index","Home");
        }

        public ActionResult GoodLogin()
        {
            return View();
        }

        public ActionResult BadLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signup(LoginTable userInfo)
        {


            if (db.LoginTables.Any(x => x.Username == userInfo.Username))
            {
               TempData["SignUpInfoMessage"] = "The account is existed";
               return View();
            }
            else if (db.LoginTables.Any(x => x.UserID == userInfo.UserID))
            {
                TempData["SignUpInfoMessage"] = "User ID is existed";
                return View();
            }
            else
            {
                db.LoginTables.Add(userInfo);
                db.SaveChanges();

                Session["UserIdSession"] = userInfo.UserID.ToString();
                Session["UserNameSession"] = userInfo.Username.ToString();

                return RedirectToAction("Index", "LoginAccount");
            }
        }



        //[HttpGet]
        //public ActionResult Registration()
        //{
        //    return View();
        //}

        //[HttpGet]
        //public ActionResult GoodSignUp()
        //{
        //    return View();
        //}

        //void connectionString()
        //{
        //    //con.ConnectionString = "data source=ASTRDINO; database=TrainDB; integrated security = SSPI; ";
        //}

        //[HttpPost]
        //public ActionResult Verify(LoginAccount account)
        //{

        //    connectionString();

        //    con.Open();

        //    com.Connection = con;
        //    com.CommandText = "select * from LoginTable where Username='"+account.Username+"' and Password='"+account.Password+"'";

        //    dr = com.ExecuteReader();

        //    if (dr.Read())
        //    {
        //        con.Close();
        //        return View("GoodLogin");
        //    }
        //    else
        //    {
        //        con.Close();
        //        return View("BadLogin");
        //    }

           
           
        //}

        //[HttpPost]
        //public bool isDuplicateUser(LoginAccount account)
        //{

        //    connectionString();

        //    con.Open();

        //    com.Connection = con;
        //    com.CommandText = "select * from LoginTable where Username='" + account.Username + "' and Password='" + account.Password + "'";

        //    dr = com.ExecuteReader();

        //    if (dr.Read())
        //    {
        //        con.Close();
        //        return true;
        //    }
        //    else
        //    {
        //        con.Close();
        //        return false;
        //    }
        //}

        //[HttpPost]
        //public ActionResult AddUser(LoginAccount account)
        //{

        //    bool check = isDuplicateUser(account);

        //    if (!check)
        //    {
        //        connectionString();

        //        con.Open();

        //        SqlCommand add_cmd = new SqlCommand("Insert", con);
        //        add_cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //        //add_cmd.Parameters.AddWithValue("@User");

        //        //com.Connection = con;
        //        //int currentId = (int)com.ExecuteScalar() + 1; //Obtain the amt of Login Users

        //        //com.CommandText = "INSERT INTO [trainDB].[dbo].[LoginTable](UserID,Username, Password, isAdmin) VALUES ('" + currentId + "', '" + "Dino1','Dino1',1)";

        //        //com.ExecuteNonQuery();
        //    }

            

        //    con.Close();
        //    return View("GoodSignUp");
           
        //    //if (i >= 1)
        //    //{

        //    //    con.Close();
        //    //    return View("GoodSignUp");;

        //    //}
        //    //else
        //    //{

        //    //    con.Close();
        //    //    return View("ExistedUser");
        //    //}







        //}

  
    }
}