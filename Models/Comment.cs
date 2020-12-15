using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mercedes_benz.Models
{
    [FirestoreData]
    public class Comment
    {
        [FirestoreProperty]
        public string id { get; set; }

        [FirestoreProperty]
        public string user { get; set; }

        [FirestoreProperty]
        public string car { get; set; }

        [FirestoreProperty]
        public string content { get; set; }

        [FirestoreProperty]
        public DateTime publishAt { get; set; }
    }
}