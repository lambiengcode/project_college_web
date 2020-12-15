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
    public class InfoController : Controller
    {
        FirestoreDb db;
        List<Car> list = new List<Car>();
        // GET: Car
        public async Task<ActionResult> Index(Car car, User user)
        {
            await initialDB();
            //addDataToFirestore();            
            return View();
        }

        async Task initialDB()
        {
            string paths = AppDomain.CurrentDomain.BaseDirectory + @"mercedes-benz-98159-firebase-adminsdk-qsnd1-c6531e2bfd.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", paths);
            db = FirestoreDb.Create("mercedes-benz-98159");
            
        }
    }
}