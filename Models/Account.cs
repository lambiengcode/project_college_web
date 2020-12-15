using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Google.Cloud.Firestore;

namespace mercedes_benz.Models
{
    [FirestoreData]
    public class Account
    {
        [FirestoreProperty]
        public string uid { get; set; }
        [Compare("password")]
        [FirestoreProperty]
        public string username { get; set; }
        [FirestoreProperty]
        public string password { get; set; }
        [Compare("password")]
        public string confirmPassword { get; set; }
    }
}