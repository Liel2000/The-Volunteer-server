using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DTO;

namespace WebApplication4.Controllers
{
    [RoutePrefix("api/volunteer")]
    public class VolunteerController : ApiController
    {
        // GET: api/Volunteer
        [Route("get")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Volunteer/5
        [Route("get/{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Volunteer
        [HttpPost]
        [Route("addVolunteer")]
        public bool AddVolunteer( [FromBody] Volunteer valunteer)
        {
            return BL.VolunteerBL.AddVolunteer(valunteer);
        }

        // PUT: api/Volunteer/5
        public void Put(int id, [FromBody]string value)
        {

        }

        // DELETE: api/Volunteer/5
        public void Delete(int id)
        {
        }
        [HttpGet]
        [Route("GetPersonalStatus")]
        public List<PersonalStatus> GetPersonalStatuses()
        {
            return BL.VolunteerBL.GetPersonalStatuses();
        }
        [HttpGet]
        [Route("GetGender")]
        public List<Gender> GetGender()
        {
            return BL.VolunteerBL.GetGender();
        }
        [HttpGet]
        [Route("GetCarLicense")]
        public List<CarLicense> GetCarLicense()
        {
            return BL.VolunteerBL.GetCarLicense();
        }
        [HttpGet]
        [Route("GetWeaponsLicense")]
        public List<WeaponsLicense> GetWeaponsLicense()
        {
            return BL.VolunteerBL.GetWeaponsLicense();
        }
        [HttpGet]
        [Route("GetDays")]
        public List<Days> GetDays()
        {
            return BL.VolunteerBL.GetDays();
        }
        [HttpGet]
        [Route("GetShift")]
        public List<Shift> GetShift()
        {
            return BL.VolunteerBL.GetShift();
        }
        [HttpGet]
        [Route("GetAvailability")]
        public List<Availability> GetAvailability()
        {
            return BL.VolunteerBL.GetAvailability();
        }
        [HttpGet]
        [Route("GetLanguage")]
        public List<Language> GetLanguage()
        {
            return BL.VolunteerBL.GetLanguage();
        }
        [HttpGet]
        [Route("GetAvailabilitys")]
        public List<Availability> GetAvailabilitys()
        {
            return BL.VolunteerBL.GetAvailabilitys();
        }
        [HttpGet]
        [Route("GetCity")]
        public List<City> GetCity()
        {
            return BL.VolunteerBL.GetCity();
        }
        [HttpGet]
        [Route("GetServices")]
        public List<Services> GetServices()
        {
            return BL.VolunteerBL.GetServices();
        }
        
        //[HttpGet]
        //[Route("getBtId/{id_volunteer}")]
        //public List<Volunteer> getById(string id_volunteer)
        //{
        //    return BL.VolunteerBL.getById();
        //}
    }
}
