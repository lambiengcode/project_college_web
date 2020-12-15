using Google.Cloud.Firestore;
using mercedes_benz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace mercedes_benz.Controllers
{
    public class RegisterController : Controller
    {
        public static string idMe = "brmv8Thc1zei5QtYeFIlB7ultXH3";
        FirestoreDb db;
        // GET: Register
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            await initialDB();
            return View();
        }

        async Task initialDB()
        {
            string paths = AppDomain.CurrentDomain.BaseDirectory + @"mercedes-benz-98159-firebase-adminsdk-qsnd1-c6531e2bfd.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", paths);
            db = FirestoreDb.Create("mercedes-benz-98159");
            //await getAllFromUsers();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(Account acc)
        {
            await initialDB();
            if(acc.password == acc.confirmPassword)
            {
                Query query = db.Collection("users")
                .WhereEqualTo("username", acc.username);
                QuerySnapshot snapshots = await query.GetSnapshotAsync();
                foreach (DocumentSnapshot doc in snapshots)
                {
                    //User Exists
                    ViewBag.error = "User Exists. Try again!";
                    return View("Index");
                }

                CollectionReference collection = db.Collection("users");
                Dictionary<string, object> data = new Dictionary<string, object>()
                {
                    {"id", DateTime.Now.ToBinary().ToString() },
                    {"username", acc.username },
                    {"password", acc.password },
                };
                await collection.AddAsync(data);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                //Not Compare
                ViewBag.error = "Don't match";
                return View("Index");
            }
            
        }
    }
}