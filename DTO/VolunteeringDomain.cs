using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
  public class VolunteeringDomain
  {
        public int code_volunteering { get; set; }
        public int code_domain { get; set; }
        public string description { get; set; }
        public bool IsSelected { get; set; }

        public static VolunteeringDomain convertvolunteeringdomaintablevolunteeringdomainentity(volunteering_domain v)
        {

            VolunteeringDomain v1 = new VolunteeringDomain()
            {
                code_volunteering = v.code_volunteering,
                code_domain = v.code_domain,
                description = v.description
            };
            return v1;
        }
        public static volunteering_domain convertvolunteeringdomainentitytovolunteeringdomaintable(VolunteeringDomain v)
        {
            volunteering_domain v1 = new volunteering_domain()
            {
                code_volunteering = v.code_volunteering,
                code_domain = v.code_domain,
                description = v.description
            };
            return v1;
        }

        public static List<VolunteeringDomain> convertvolunteeringdomaintabletolistvolunteeringdomainentity(List<volunteering_domain> vl)
        {
            List<VolunteeringDomain> v1 = new List<VolunteeringDomain>();
            foreach (var item in vl)
            {
                v1.Add(convertvolunteeringdomaintablevolunteeringdomainentity(item));
            }
            return v1;
        }
        public static List<volunteering_domain> convertvolunteeringdomainentitytolistvolunteeringdomaintable(List<VolunteeringDomain> vl)
        {
            List<volunteering_domain> v1 = new List<volunteering_domain>();
            foreach (var item in vl)
            {
                v1.Add(convertvolunteeringdomainentitytovolunteeringdomaintable(item));
            }
            return v1;
        }
    }
}
