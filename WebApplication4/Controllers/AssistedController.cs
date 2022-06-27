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
    [RoutePrefix("api/assisted")]
    public class AssistedController : ApiController
    {
        // GET: api/Assisted
        [Route("get")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Assisted/5
        [Route("get/{id}")]
        public string Get(int id)
        {
            return "value";
        }

        //[HttpPost]
        //[Route("embededAssisted")]
        //public bool EmbededAssisted([FromBody] Assisted assisted)
        //{
        //    return BL.AssistedBL.EmbededAssisted1(assisted);
        //}
        [HttpPost]
        [Route("GetEmbededAssisteds")]
        public List<EmbeddindAssisted> GetEmbededAssisteds([FromBody] Volunteer volunteer)
        {
            return BL.AssistedBL.GetEmbededAssisteds(volunteer);
        }
        [HttpPost]
        [Route("SendMessagesToAssisteds")]
        public bool SendMessagesToAssisteds([FromBody] List<EmbeddindAssisted> embeddindAssisteds)
        {
            return BL.AssistedBL.SendMessagesToAssisteds(embeddindAssisteds);
        }
        // POST: api/Assisted
        [HttpPost]
        [Route("addAssisted")]
        public bool AddAssisted( [FromBody] Assisted assisted)
        {

            return BL.AssistedBL.AddAssisted(assisted);
        }

        // PUT: api/Assisted/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Assisted/5
        public void Delete(int id)
        {
        }
        [HttpGet]
        [Route("GetPersonalStatus")]
        public List<PersonalStatus> GetPersonalStatuses()
        {
            return BL.AssistedBL.GetPersonalStatuses();
        }
        [HttpGet]
        [Route("GetGender")]
        public List<Gender> GetGender()
        {
            return BL.AssistedBL.GetGender();
        }
        [HttpGet]
        [Route("GetLanguage")]
        public List<Language> GetLanguage()
        {
            return BL.AssistedBL.GetLanguage();
        }
        [HttpGet]
        [Route("GetCity")]
        public List<City> GetCity()
        {
            return BL.AssistedBL.GetCity();
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
        [Route("GetAvailabilitys")]
        public List<Availability> GetAvailabilitys()
        {
            return BL.AssistedBL.GetAvailabilitys();
        }
        [HttpGet]
        [Route("GetAvailability")]
        public List<Availability> GetAvailability()
        {
            return BL.VolunteerBL.GetAvailability();
        }
        //[HttpPost("SendMail/{volunteer}")]
        //public IActionResult SendMail(volunteer volunteer, [FromBody]  )
        //{
        //    try
        //    {
        //        var kimat_erua = erua.kimat_erua1 == 1 ? "אירוע" : "כמעט אירוע";
        //        var message = "<div style='direction:rtl;;font-family:Arial;'>" +
        //      "שלום רב, </br> </br>" +
        //       "דיווח: " + kimat_erua + " חריג " +
        //       "</br>" +
        //       "</br>" +
        //        " דווח על " + kimat_erua + " חריג. " + "</br>" + "עליך להכנס למערכת כדי לראות את פרטי האירוע ." + "</br>" +
        //        "מספר האירוע: " + erua.erua_no + "</br>" + "תאריך האירוע:  " + erua.taarich_erua.ToString();
        //        לשלוח מייל
        //        SendMail(volunteer, erua, " דיווח" + kimat_erua + " חריג ", message);
        //        return Ok(true);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
    }
}
