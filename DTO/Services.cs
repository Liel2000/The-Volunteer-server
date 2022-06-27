using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public  class Services
    {
        public int code_service { get; set; }
        public string description { get; set; }

        public static Services convetservicestabletoserviceentity(services s)
        {
            Services s1 = new Services()
            {
                code_service = s.code_service,
                description = s.description,
            };
            return s1;
        }
        public static services convetservicesentitytoservicetable(Services s)
        {
            services s1 = new services()
            {
                code_service = s.code_service,
                description = s.description,
            };
            return s1;
        }
        public static List<Services> convertservicestabletolistservicesentity(List<services> sl)
        {
            List<Services> s1 = new List<Services>();
            foreach (var item in sl)
            {
                s1.Add(convetservicestabletoserviceentity(item));
            }
            return s1;
        }
        public static List<services> convertservicesentitytolistservicestable(List<Services> sl)
        {
            List<services> s1 = new List<services>();
            foreach (var item in sl)
            {
                s1.Add(convetservicesentitytoservicetable(item));
            }
            return s1;
        }
    }
}
