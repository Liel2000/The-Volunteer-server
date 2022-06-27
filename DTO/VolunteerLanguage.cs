using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
     public class VolunteerLanguage
     {
        public int code_volunteer_language { get; set; }
        public int code_language { get; set; }
        public string id_volunteer { get; set; }

        public static VolunteerLanguage convertvolunteerlanguagetabletovolunteerlanguageentity(volunteer_language v)
        {
            VolunteerLanguage v1 = new VolunteerLanguage()
            {
                code_volunteer_language = v.code_volunteer_language,
                code_language = v.code_language,
                id_volunteer = v.id_volunteer
            };
            return v1;
        }

        public static volunteer_language convertvolunteerlanguageentitytovolunteerlanguagetable(VolunteerLanguage v)
        {
            volunteer_language v1 = new volunteer_language()
            {
                code_volunteer_language = v.code_volunteer_language,
                code_language = v.code_language,
                id_volunteer = v.id_volunteer
            };
            return v1;
        }

        public static List<VolunteerLanguage> convertvolunteerlanguagetabletolistvolunteerlanguageentity(List<volunteer_language> vl)
        {
            List<VolunteerLanguage> v1 = new List<VolunteerLanguage>();
            foreach (var item in vl)
            {
                v1.Add(convertvolunteerlanguagetabletovolunteerlanguageentity(item));
            }
            return v1;
        }
        public static List<volunteer_language> convertvolunteerlanguageentitytolistvolunteerlanguagetable(List<VolunteerLanguage> vl)
        {
            List<volunteer_language> v1 = new List<volunteer_language>();
            foreach (var item in vl)
            {
                v1.Add(convertvolunteerlanguageentitytovolunteerlanguagetable(item));
            }
            return v1;
        }
    }
}
