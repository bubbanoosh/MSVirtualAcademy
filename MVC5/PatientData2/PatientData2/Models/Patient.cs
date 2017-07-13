using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace PatientData2.Models
{
    /// <summary>
    /// PatientData class
    /// </summary>
    public class Patient
    {
        /// <summary>
        /// Bson represented ObjectId for patient
        /// </summary>
        [BsonElement("_Id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        /// <summary>
        /// string: Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// ICollection: Ailment
        /// </summary>
        public ICollection<Ailment> Ailments { get; set; }
        /// <summary>
        /// ICollection: Medication
        /// </summary>
        public ICollection<Medication> Medications { get; set; }
    }

    /// <summary>
    /// Medication for a patient
    /// </summary>
    public class Medication
    {
        /// <summary>
        /// string: Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// int: Doses
        /// </summary>
        public int Doses { get; set; }
    }
    /// <summary>
    /// A Patient's Ailments
    /// </summary>
    public class Ailment
    {
        /// <summary>
        /// Name of an Ailment
        /// </summary>
        public string Name { get; set; }
    }
}