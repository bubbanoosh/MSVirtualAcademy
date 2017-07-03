using PatientData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver.Linq;
using MongoDB.Driver;

namespace PatientData.App_Start
{
    /// <summary>
    /// 
    /// </summary>
    public static class MongoConfig
    {
        /// <summary>
        /// 
        /// </summary>
        public static void Seed()
        {
            var patients = PatientDB.Open();

            if (!patients.AsQueryable().Any(p => p.Name == "Errol"))
            {
                var data = new List<Patient>()
                {
                    new Patient { Name = "Errol",
                                    Ailments = new List<Ailment>() {
                                        new Ailment { Name = "Crazy ailment 1" },
                                        new Ailment { Name = "Crazy ailment 2" },
                                        new Ailment { Name = "Crazy ailment 3" },
                                        new Ailment { Name = "Crazy ailment 4" }
                                    },
                                    Medications = new List<Medication>() {
                                        new Medication { Name = "Med 1" },
                                        new Medication { Name = "Med 4" }
                                    }
                    },
                    new Patient { Name = "Fred",
                                    Ailments = new List<Ailment>() {
                                        new Ailment { Name = "Crazy ailment 1" },
                                        new Ailment { Name = "Other ailment 2" },
                                        new Ailment { Name = "Crazy ailment 3" },
                                        new Ailment { Name = "Crazy ailment 4" }
                                    },
                                    Medications = new List<Medication>() {
                                        new Medication { Name = "Med 1" },
                                        new Medication { Name = "Med 4" }
                                    }
                    },
                    new Patient { Name = "Angie",
                                    Ailments = new List<Ailment>() {
                                        new Ailment { Name = "Crazy ailment 1" },
                                        new Ailment { Name = "Crazy ailment 3" },
                                        new Ailment { Name = "Crazy ailment 5" },
                                        new Ailment { Name = "Crazy ailment 8" }
                                    },
                                    Medications = new List<Medication>() {
                                        new Medication { Name = "Med 5" },
                                        new Medication { Name = "Med 4" }
                                    }
                    },
                };

                patients.InsertMany(data);
            }
        }

    }
}