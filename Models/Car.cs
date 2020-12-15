using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mercedes_benz.Models
{
    [FirestoreData]
    public class Car
    {
        [FirestoreProperty]
        public string id { get; set; }

        [FirestoreProperty]
        public string name { get; set; }

        [FirestoreProperty]
        public List<string> colors { get; set; }

        [FirestoreProperty]
        public List<string> images { get; set; }

        [FirestoreProperty]
        public string desc { get; set; }

        [FirestoreProperty]
        public string spec { get; set; }

        [FirestoreProperty]
        public string price { get; set; }

        [FirestoreProperty]
        public int type { get; set; }
    }
}