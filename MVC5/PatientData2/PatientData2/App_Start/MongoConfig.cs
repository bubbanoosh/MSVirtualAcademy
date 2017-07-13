using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PatientData2.Models;
using MongoDB.Driver.Linq;
using MongoDB.Driver;

namespace PatientData2.App_Start
{
    /// <summary>
    /// Mongo Configuration primarily using this to seed data into Mongo
    /// </summary>
    public static class MongoConfig
    {
        /// <summary>
        /// Seed method to insert Patients, Ailments and meds
        /// </summary>
        public static void Seed()
        {
            var patients = PatientDb.Open();

            if (!patients.AsQueryable().Any(p => p.Name == "Errol"))
            {
                var data = new List<Patient>()
                {
                    new Patient {
                        Name = "Errol",
                        Ailments = new List<Ailment>() { new Ailment { Name="Crazy Flu"}, new Ailment { Name = "Really shitty sickness"} },
                        Medications = new List<Medication>() { new Medication { Name = "Penicillin", Doses = 100 }, new Medication { Name = "Codine", Doses = 3 }, new Medication { Name = "Good meds", Doses = 1 } }
                    },
                    new Patient
                    {
                        Name = "Jakotay",
                        Ailments = new List<Ailment>() { new Ailment { Name = "Bird Flu" }, new Ailment { Name = "The poops" } },
                        Medications = new List<Medication>() { new Medication { Name = "Penicillin", Doses = 5 }, new Medication { Name = "Codine", Doses = 3 }, new Medication { Name = "Other meds", Doses = 1 } }
                    },
                    new Patient
                    {
                        Name = "Jaynilee",
                        Ailments = new List<Ailment>() { new Ailment { Name = "Stomach Flu" }, new Ailment { Name = "Wee wee sickness" } },
                        Medications = new List<Medication>() { new Medication { Name = "Penicillin", Doses = 4 }, new Medication { Name = "Codine", Doses = 28 }, new Medication { Name = "Good meds", Doses = 10 } }
                    }
                };

                //INSERT
                patients.InsertMany(data);
            }
        }
    }
}