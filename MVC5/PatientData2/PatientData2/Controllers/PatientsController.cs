using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MongoDB.Driver;
using PatientData2.Models;
using MongoDB.Driver.Linq;
using MongoDB.Bson;

namespace PatientData2.Controllers
{
    /// <summary>
    /// Controller for patients
    /// </summary>
    [RoutePrefix("api/patients")]
    public class PatientsController : ApiController
    {


        private readonly IMongoCollection<Patient> _patients;

        public PatientsController()
        {
            _patients = PatientDb.Open();
        }

        [HttpGet]
        public IEnumerable<Patient> Get()
        {
            return _patients.Find(new BsonDocument()).ToEnumerable();
        }

        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        /// <summary>
        /// WEBAPI 1.0 version
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("{id}/medications")]
        public HttpResponseMessage GetMedications(string id)
        {
            var collection = _patients;
            var filter = Builders<Patient>.Filter.Eq("Id", ObjectId.Parse(id));
            var patient = collection.Find(filter).ToList().FirstOrDefault();

            if (patient == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Medications NOOOOT Found...");
            }
            else
            {
                return Request.CreateResponse(patient.Medications);
            }
        }

        /// <summary>
        /// WebAPI 1.0 version
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("{id}")]
        //[HttpGet]
        public HttpResponseMessage Get([FromUri]string id)
        {
            var filter = Builders<Patient>.Filter.Eq("Id", ObjectId.Parse(id));
            var patient = _patients.Find(filter).ToList().FirstOrDefault();

            if (patient == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Patient was NOOOOT Found...");
            }
            else
            {
                return Request.CreateResponse(patient);
            }
        }




        // GET api/<controller>/5
        //[Route("api/patients/{id:int}")]
        //public Patient Get(int id)
        //{
        //    return _patients.Find(new BsonDocument()).First();
        //}

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}