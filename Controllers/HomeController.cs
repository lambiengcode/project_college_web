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
    public class HomeController : Controller
    {
        public static string idMe = "brmv8Thc1zei5QtYeFIlB7ultXH3";
        FirestoreDb db;
        
        List<Car> list = new List<Car>();
        // GET: Car
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            await initialDB();
            //addDataToFirestore(); 
            Query query = db.Collection("cars");
            QuerySnapshot snapshots = await query.GetSnapshotAsync();
            foreach (DocumentSnapshot doc in snapshots)
            {
                Car car = doc.ConvertTo<Car>();

                if (doc.Exists)
                {
                    list.Add(car);
                }
            }
            
            return View(list);
        }

        public ActionResult LogOut()
        {
            Session.Clear();

            return RedirectToAction("Index");
        }

        async Task initialDB()
        {
            string paths = AppDomain.CurrentDomain.BaseDirectory + @"mercedes-benz-98159-firebase-adminsdk-qsnd1-c6531e2bfd.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", paths);
            db = FirestoreDb.Create("mercedes-benz-98159");
            //await getAllFromCars();
            //await addDataToFirestore();
        }

        async Task addDataToFirestore()
        {
            CollectionReference collection = db.Collection("cars");
            Dictionary<string, object> data = new Dictionary<string, object>()
            {
                {"id" , "1234" },
            };
            await collection.AddAsync(data);
        }

        async Task getCustomFromCars(int number)
        {
            Query query = db.Collection("cars")
                .WhereEqualTo("type", number);
            QuerySnapshot snapshots = await query.GetSnapshotAsync();
            foreach (DocumentSnapshot doc in snapshots)
            {
                Car car = doc.ConvertTo<Car>();

                if (doc.Exists)
                {                    
                    list.Add(car);
                    System.Diagnostics.Debug.WriteLine(car.name);

                }
            }
        }
    }
}