using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BL
{
   public class VolunteeringBL
   {
        public static Progect_lEntities db = new Progect_lEntities();
        public static List<VolunteeringDomain> getall()
        {
            List<volunteering_domain> volunteeringdomain = db.volunteering_domain.ToList();
            return VolunteeringDomain.convertvolunteeringdomaintabletolistvolunteeringdomainentity(volunteeringdomain);
        }
        public static VolunteeringDomain getBtId(int code_volunteering)
        {
            volunteering_domain volunteeringdomain = db.volunteering_domain.FirstOrDefault(x => code_volunteering == code_volunteering);
            return VolunteeringDomain.convertvolunteeringdomaintablevolunteeringdomainentity(volunteeringdomain);
        }
        public static List<VolunteeringDomain> AddVolunteering(VolunteeringDomain volunteeringdomain)
        {
            db.volunteering_domain.Add(VolunteeringDomain.convertvolunteeringdomainentitytovolunteeringdomaintable(volunteeringdomain));
            db.SaveChanges();
            return VolunteeringDomain.convertvolunteeringdomaintabletolistvolunteeringdomainentity(db.volunteering_domain.ToList());
        }
        public static List<VolunteeringDomain> RemoveVolunteering(int code_volunteering)
        {
            db.volunteering_domain.Remove(db.volunteering_domain.FirstOrDefault(x => x.code_volunteering == code_volunteering));
            db.SaveChanges();
            return VolunteeringDomain.convertvolunteeringdomaintabletolistvolunteeringdomainentity(db.volunteering_domain.ToList());
        }
        public static List<VolunteeringDomain> EditVolunteering(VolunteeringDomain volunteeringdomain)
        {
            db.volunteering_domain.FirstOrDefault(x => x.code_volunteering == volunteeringdomain.code_volunteering).code_domain = volunteeringdomain.code_domain;
            db.volunteering_domain.FirstOrDefault(x => x.code_volunteering == volunteeringdomain.code_volunteering).description = volunteeringdomain.description;

            db.SaveChanges();
            return VolunteeringDomain.convertvolunteeringdomaintabletolistvolunteeringdomainentity(db.volunteering_domain.ToList());
        }
    }
}
