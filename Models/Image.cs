using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mercedes_benz.Models
{
    [FirestoreData]
    public class Image
    {
        [FirestoreProperty]
        public string car { get; set; }

        [FirestoreProperty]
        public string color { get; set; }

        [FirestoreProperty]
        public string image { get; set; }

    }
}