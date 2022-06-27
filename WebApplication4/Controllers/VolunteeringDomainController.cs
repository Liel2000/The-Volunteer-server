using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DTO;
using BL;

namespace WebApplication4.Controllers
{
    [RoutePrefix("api/volunteerDomain")]
    public class VolunteeringDomainController : ApiController
    {
        // GET: api/VolunteeringDomain
        [Route("get")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/VolunteeringDomain/5
        [HttpGet]
        [Route("getDomainList")]
        public List<Domain> GetDomainsList()
        {
            return BL.DomainBL.GetDomainsList();
        }

        //[HttpGet]
        //[Route("getDomainLists")]
        //public  GetDomainsLists()
        //{ 
        //    return  BL.DomainBL.GetDomainsLists();
        //}
        [HttpGet]
        [Route("getVolunteeringDomain/{code_domain}")]
        public List<VolunteeringDomain> GetVolunteeringDomain(int code_domain)
        {
            return BL.DomainBL.GetVolunteeringDomain(code_domain);
        }
        // POST: api/VolunteeringDomain
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/VolunteeringDomain/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/VolunteeringDomain/5
        public void Delete(int id)
        {
        }

        [HttpGet]
        [Route("GetDomain")]
        public List<Domain> GetDomain()
        {
            return BL.DomainBL.GetDomain();
        }
    }
}
