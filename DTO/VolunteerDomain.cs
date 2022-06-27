using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class VolunteerDomain
   {
        public int code_volunteer_domain { get; set; }
        public int code_volunteering { get; set; }
        public string id_volunteer { get; set; }
      

        public static VolunteerDomain convertvolunteerdomaintabletovolunteerdomainentity(volunteer_domain v)
        {
            VolunteerDomain v1 = new VolunteerDomain()
            {
                code_volunteer_domain = v.code_volunteer_domain,
                code_volunteering = v.code_volunteering,
                id_volunteer = v.id_volunteer
            };
            return v1;
        }
        public static volunteer_domain convertvolunteerdomainentitytoavolunteerdomaintable(VolunteerDomain v)
        {
            volunteer_domain v1 = new volunteer_domain()
            {
                code_volunteer_domain = v.code_volunteer_domain,
                code_volunteering = v.code_volunteering,
                id_volunteer = v.id_volunteer
            };
            return v1;
        }

        public static List<VolunteerDomain> convertvolunteerdomaintabletolistvolunteerdomainentity(List<volunteer_domain> vl)
        {
            List<VolunteerDomain> v1 = new List<VolunteerDomain>();
            foreach (var item in vl)
            {
                v1.Add(convertvolunteerdomaintabletovolunteerdomainentity(item));
            }
            return v1;
        }
        public static List<volunteer_domain> convertvolunteerdomainentitytolistvolunteerdomaintable(List<VolunteerDomain> vl)
        {
            List<volunteer_domain> v1 = new List<volunteer_domain>();
            foreach (var item in vl)
            {
                v1.Add(convertvolunteerdomainentitytoavolunteerdomaintable(item));
            }
            return v1;
        }
    }
}
