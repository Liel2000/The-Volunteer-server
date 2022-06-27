using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace DTO
{
    public class Assisted
    {
        public string id_assisted { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public Nullable<System.DateTime> date_birth { get; set; }
        public Nullable<int> code_status { get; set; }
        public Nullable<int> code_gender { get; set; }
        public Nullable<int> code_city { get; set; }
        public string street { get; set; }
        public Nullable<int> number_house { get; set; }
        public Nullable<int> number_building { get; set; }
        public Nullable<int> number_floor { get; set; }
        public string postal_code { get; set; }
        public string e_mail { get; set; }
        public string phone { get; set; }
        public string password { get; set; }

        public List<Language> languages { get; set; }
        //public List<string> domain { get; set; }
        public Availability availability { get; set; }
        public List<VolunteeringDomain> volunteeringdomains { get; set; }
        public List<Availability> availabilitys { get; set; }



        public static Assisted convertassistedtabletoassistedentity(assisted a)
        {
            Assisted a1 = new Assisted()
            {
                id_assisted=a.id_assisted,
                first_name=a.first_name,
                last_name=a.last_name,
                date_birth=a.date_birth,
                code_gender=a.code_gender,
                code_city=a.code_city,
                code_status=a.code_status,
                postal_code=a.postal_code,
                e_mail=a.e_mail,
                street=a.street,
                number_building=a.number_building,
                number_house=a.number_house,
                number_floor=a.number_floor,
                phone = a.phone,
                password = a.password,
            };
            return a1;
        }
        public static List<assisted_language> ConvertLanguageEntityListToAssistedLanguage(List<Language> languages, string assistedId)
        {
            List<assisted_language> alList = new List<assisted_language>();
            foreach (Language l in languages)
            {
                if (l.IsSelected == true)
                {
                    assisted_language al = new assisted_language();
                    al.id_assisted = assistedId;
                    al.code_language = l.code_language;
                    alList.Add(al);

                }
            }
            return alList;
        }
        public static List<assisted_domain> ConvertVolunteeringDomainEntityListToAssistedDomain(List<VolunteeringDomain> volunteeringdomains, string assistedId)
        {
            List<assisted_domain> adList = new List<assisted_domain>();
            foreach (VolunteeringDomain d in volunteeringdomains)
            {
                if (d.IsSelected == true)
                {
                    assisted_domain al = new assisted_domain();
                    al.id_assisted = assistedId;
                    al.code_volunteering = d.code_volunteering;
                    adList.Add(al);
                }
            }
            return adList;
        }
        public static List<assisted_availability> ConvertAvailabilityEntityListToAssistedAvailability(List<Availability> availabilitys, string assisted_Id)
        {
            List<assisted_availability> AvailabilityList = new List<assisted_availability>();
            foreach (Availability a in availabilitys)
            {
                if (a.IsSelected == true)
                {
                    assisted_availability al = new assisted_availability();
                    al.id_assisted = assisted_Id;
                    al.code_availability = a.code_availability;
                    AvailabilityList.Add(al);

                }
            }
            return AvailabilityList;
        }
        public static assisted convertassistedentitytoassistedtable(Assisted a)
        {
            assisted a1 = new assisted()
            {
                id_assisted = a.id_assisted,
                first_name = a.first_name,
                last_name = a.last_name,
                date_birth = a.date_birth,
                code_gender = a.code_gender,
                code_city = a.code_city,
                code_status = a.code_status,
                postal_code = a.postal_code,
                e_mail = a.e_mail,
                street = a.street,
                number_building = a.number_building,
                number_house = a.number_house,
                number_floor = a.number_floor,
                phone = a.phone,
                password = a.password
            };
            return a1;
        }
        public static List<Assisted> convertassistedtabletolistassistedentity(List<assisted> al)
        {
            List<Assisted> a1 = new List<Assisted>();
            foreach (var item in al)
            {
                a1.Add(convertassistedtabletoassistedentity(item));
            }
            return a1;
        }
        public static List<assisted> convertassistedentitytolistassistedtable(List<Assisted> al)
        {
            List<assisted> a1 = new List<assisted>();
            foreach (var item in al)
            {
                a1.Add(convertassistedentitytoassistedtable(item));
            }
            return a1;
        }
    }
}
