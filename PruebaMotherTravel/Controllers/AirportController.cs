using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PruebaMotherTravel.Models;

namespace PruebaMotherTravel.Controllers
{
    public class AirportController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<Airport> Get()
        {
            using (var db = new AppContext())
            {
                return db.Airports.ToList();
            }
        }

        // GET api/<controller>/iataCode
        [HttpGet]
        [Route("api/airport/getByIata/{iata}")]
        public IEnumerable<Airport> GetByIata(string iata)
        {
            using (var db = new AppContext())
            {
                return db.Airports.Where(x => x.IataCode == iata).ToList();
            }
        }

        // GET api/<controller>/5
        public Airport Get(int id)
        {
            using (var db = new AppContext())
            {
                return db.Airports.FirstOrDefault(x => x.Id == id);
            }
        }

        // POST api/<controller>
        public HttpResponseMessage Post(Airport model)
        {
            using (var db = new AppContext())
            {
                if (ModelState.IsValid)
                {
                    var toInsert = new Airport
                    {
                        IataCode = model.IataCode,
                        Description = model.Description
                    };
                    try
                    {
                        db.Airports.Add(toInsert);
                        db.SaveChanges();
                        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, model);
                        return response;
                    }
                    catch (Exception)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error while attemp to save in database");
                    }
                }

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
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