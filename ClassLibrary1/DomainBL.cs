using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BL
{
    public class DomainBL
    {
        public static Progect_lEntities db = new Progect_lEntities();
        public static List<Domain> GetDomainsList()
        {
            List<domain> domain = db.domain.ToList();
            return Domain.convertdomaintabletolistdomainentity(domain);
        }
        public static Domain getBtId(int code_domain)
        {
            domain domain = db.domain.FirstOrDefault(x => code_domain == code_domain);
            return Domain.convertdomaintabletodomainentity(domain);
        }
        public static List<Domain> AddDomain(Domain domain)
        {
            db.domain.Add(Domain.convertdomainentitytodomaintable(domain));
            db.SaveChanges();
            return Domain.convertdomaintabletolistdomainentity(db.domain.ToList());
        }

        public static List<Domain> RemoveDomain(int code_domaim)
        {
            db.domain.Remove(db.domain.FirstOrDefault(x => x.code_domain == code_domaim));
            db.SaveChanges();
            return Domain.convertdomaintabletolistdomainentity(db.domain.ToList());
        }
        public static List<Domain> EditDomain(Domain domain)
        {
            db.domain.FirstOrDefault(x => x.code_domain == domain.code_domain).description = domain.description;
            db.SaveChanges();
            return Domain.convertdomaintabletolistdomainentity(db.domain.ToList());
        }
        public static List<VolunteeringDomain> GetVolunteeringDomain(int code_domain)
        {
            try
            {
                List<volunteering_domain> volunteerings = new List<volunteering_domain>();
                 volunteerings = db.volunteering_domain.Where(x => x.code_domain == code_domain).ToList();
                return VolunteeringDomain.convertvolunteeringdomaintabletolistvolunteeringdomainentity(volunteerings);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static List<Domain> GetDomain()
        {
            Progect_lEntities db = new Progect_lEntities();
            List<Domain> list = new List<Domain>();
            foreach (var item in db.domain)
            {
                list.Add(new Domain { code_domain = item.code_domain, description = item.description });
            }
            return list;
        }
    }
}
