using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PatientData.Controllers
{
    /// <summary>
    /// The Values controller inherits ApiController
    /// </summary>
    public class ValuesController : ApiController
    {
        
        /// <summary>
        /// This uses IEnumerable<string> in the Get()
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        ///// <summary>
        ///// Find out if Angie is sick due to bad additives or preservities
        ///// and return a message to the user
        ///// </summary>
        ///// <returns></returns>
        //public string IsAngieSick(string name)
        //{
        //    bool sick = false;
        //    string cutie = name;
        //    int[] poisons = [220, 180, 635];

        //    if (cutie == "Angie")
        //    {
        //        foreach (int poison in poisons)
        //        {
        //            if (poison == 220 || poison == 635)
        //            {
        //                sick = true;
        //                break;
        //            }
        //        }

        //        return sick ? cutie + " is sick" : cutie + " is not sick :) <3";
        //    }
        //    else
        //    {
        //        return "We don't care about anyone else :)";
        //    }

        //}


        // GET api/values/5
        /// <summary>
        /// This uses int id in the Get()
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        /// <summary>
        /// This is a Post([FromBody]string value) 
        /// </summary>
        /// <param name="value"></param>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        /// <summary>
        /// Uses Put(int id, [FromBody]string value)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        /// <summary>
        /// Delete method accepts int id
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
        }
    }
}
