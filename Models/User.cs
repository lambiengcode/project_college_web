using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mercedes_benz.Models
{
    [FirestoreData]
    public class User
    {
        [FirestoreProperty]
        public string id { get; set; }

        [FirestoreProperty]
        public string username { get; set; }

        [FirestoreProperty]
        public string email { get; set; }

        [FirestoreProperty]
        public string phone { get; set; }

        [FirestoreProperty]
        public string image { get; set; }
    }
}