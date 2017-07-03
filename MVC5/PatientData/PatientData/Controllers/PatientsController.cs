using MongoDB.Driver;
using PatientData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MongoDB.Bson;


namespace PatientData.Controllers
{
    public class PatientsController : ApiController
    {
        IMongoCollection<Patient> _patients;


        public PatientsController()
        {
            _patients = PatientDB.Open();
        }

        //public IEnumerable<Patient> Get()
        //{
        //    return _patients.FindAll();
        //}

        /// <summary>
        /// WEBAPI Version 1 Example
        /// </summary>
        [Route("patients/{id}")]
        public IHttpActionResult Get(string id)
        {
            var patient = _patients.Find(p => p.Id == id).FirstOrDefault();
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }

        /// <summary>
        /// WEBAPI Version 1 Example
        /// </summary>
        [Route("patients/{id}/medications")]
        public IHttpActionResult GetMedications(string id)
        {
            var patient = _patients.Find(p => p.Id == id).FirstOrDefault();
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient.Medications);
        }


        /*
         *    WEBAPI 1 Examples below *********************************************
         *    WEBAPI 1 Examples below *********************************************
         *    WEBAPI 1 Examples below *********************************************
         *    WEBAPI 1 Examples below *********************************************
         *    WEBAPI 1 Examples below *********************************************
         */


        /// <summary>
        /// WEBAPI Version 1 Example
        /// </summary>
        [Route("patients/{id}")]
        public HttpResponseMessage WebApi_1_Example_1(string id)
        {
            var patient = _patients.Find(p => p.Id == id).FirstOrDefault();
            if (patient == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Patient Not Foud");
            }
            return Request.CreateResponse(patient);
        }

        /// <summary>
        /// WEBAPI Version 1 Example
        /// </summary>
        [Route("patients/{id}/medications")]
        public HttpResponseMessage WebApi_1_Example_2(string id)
        {
            var patient = _patients.Find(p => p.Id == id).FirstOrDefault();
            if (patient == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Patient Not Foud");
            }
            return Request.CreateResponse(patient.Medications);
        }


        //public Patient Get(string id)
        //{
        //    var patient = _patients.Find(p => p.Id == id).FirstOrDefault();
        //}
    }

}
