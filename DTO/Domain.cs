using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Domain
    {
        public int code_domain { get; set; }

        public string description { get; set; }

        public static Domain convertdomaintabletodomainentity(domain d)
        {
            Domain d1 = new Domain()
            {
                code_domain = d.code_domain,
                description = d.description
            };
            return d1;
        }
        public static domain convertdomainentitytodomaintable(Domain d)
        {
            domain d1 = new domain()
            {
                code_domain = d.code_domain,
                description = d.description
            };
            return d1;
        }
        public static List<Domain> convertdomaintabletolistdomainentity(List<domain> dl)
        {
            List<Domain> d1 = new List<Domain>();
            foreach(var item in dl)
            {
                d1.Add(convertdomaintabletodomainentity(item));
            }
            return d1;
        }
        public static List<domain> convertdomainentitytolistdomaintable(List<Domain> dl)
        {
            List<domain> d1 = new List<domain>();
            foreach (var item in dl)
            {
                d1.Add(convertdomainentitytodomaintable(item));
            }
            return d1;
        }
    }
}
