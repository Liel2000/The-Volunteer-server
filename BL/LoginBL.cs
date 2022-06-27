using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BL
{
    public class LoginBL
    {
        public static Progect_lEntities db = new Progect_lEntities();
        public static Volunteer GetEmailAddressPassword(string e_mail, string password)
        {
            var v = (db.volunteer.FirstOrDefault(x => x.e_mail == e_mail && x.password == password));
            if (v != null )
            {
                Volunteer volunteer=Volunteer.convertvolunteertabletovolunteerentity(v);
                volunteer.languages = VolunteerBL.GetLanguageVolunteer(volunteer.id_volunteer);
                volunteer.availabilitys = VolunteerBL.GetAvailabilityVolunteer(volunteer.id_volunteer);
                volunteer.volunteeringdomains = VolunteerBL.GetVolunteeringDomain(volunteer.id_volunteer);
                return volunteer;
            }
            return null;
        }
        public static Assisted GetEmailAddressPassword1(string e_mail, string password)
        {
            var v1 = (db.assisted.FirstOrDefault(x => x.e_mail == e_mail && x.password == password));
            if (v1 != null)
            {
                Assisted assisted = Assisted.convertassistedtabletoassistedentity(v1);
                assisted.languages = AssistedBL.GetLanguageAssisted(assisted.id_assisted);
                assisted.availabilitys = AssistedBL.GetAvailabilityAssisted(assisted.id_assisted);
                assisted.volunteeringdomains = AssistedBL.GetVolunteeringDomain(assisted.id_assisted);
                return assisted;
            }
            return null;


        }
    }
}