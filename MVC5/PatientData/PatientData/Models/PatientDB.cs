using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientData.Models
{
    /// <summary>
    /// Patients Mongo Database
    /// </summary>
    public static class PatientDB
    {
        /// <summary>
        /// Get a Mongo database as 'Patients'
        /// </summary>
        /// <returns></returns>
        public static IMongoCollection<Patient> Open()
        {
            var client = new MongoClient("mongodb://localhost");
            var db = client.GetDatabase("PatientDB");

            return db.GetCollection<Patient>("Patients");
        }
    }
}