using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Google.Cloud.Firestore;
using mercedes_benz.Models;

namespace mercedes_benz.Controllers
{
    public class LoginController : Controller
    {
        public static string idMe = "brmv8Thc1zei5QtYeFIlB7ultXH3";
        FirestoreDb db;
        
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(Account acc)
        {           
            initialDB();
            Query query = db.Collection("users")
                .WhereEqualTo("username", acc.username)
                .WhereEqualTo("password", acc.password);
            QuerySnapshot snapshots = await query.GetSnapshotAsync();
            if (snapshots.Count > 0)
            {
                Account account = snapshots[0].ConvertTo<Account>();
                Session["uid"] = account.uid;
                Session["username"] = account.username;
                return RedirectToAction("Index", "Home");
            }
            else
                return View();
        }

         void initialDB()
        {
            string paths = AppDomain.CurrentDomain.BaseDirectory + @"mercedes-benz-98159-firebase-adminsdk-qsnd1-c6531e2bfd.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", paths);
            db = FirestoreDb.Create("mercedes-benz-98159");
            //await getAllFromUsers();
        }
    }
}