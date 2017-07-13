using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientData2.Models
{
    /// <summary>
    /// Data source for Patients with MongoDb
    /// </summary>
    public static class PatientDb
    {
        public static IMongoCollection<Patient> Open()
        {
            var client = new MongoClient("mongodb://localhost");
            //EntityFramework will create this if it doesn't exist
            var db = client.GetDatabase("PatientDb");
            return db.GetCollection<Patient>("Patients");
        }
    }
}