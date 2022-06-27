using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class AssistedDomain
    {
        public int code_assisted_domain { get; set; }
        public int code_volunteering { get; set; }
        public string id_assisted { get; set; }

        public static AssistedDomain convertassisteddomaintabletoassisteddomainentity(assisted_domain a)
        {
            AssistedDomain a1 = new AssistedDomain()
            {
                code_assisted_domain=a.code_assisted_domain,
                code_volunteering=a.code_volunteering,
                id_assisted=a.id_assisted
            };
            return a1;
        }
        public static assisted_domain convertassisteddomainentitytoassisteddomaintable(AssistedDomain a)
        {
            assisted_domain a1 = new assisted_domain()
            {
                code_assisted_domain = a.code_assisted_domain,
                code_volunteering = a.code_volunteering,
                id_assisted = a.id_assisted
            };
            return a1;
        }

        public static List<AssistedDomain> convertassisteddomaintabletolistassisteddomainentity(List<assisted_domain> al)
        {
            List<AssistedDomain> a1 = new List<AssistedDomain>();
            foreach (var item in al)
            {
                a1.Add(convertassisteddomaintabletoassisteddomainentity(item));
            }
            return a1;
        }
        public static List<assisted_domain> convertassisteddomainentitytolistassisteddomaintable(List<AssistedDomain> al)
        {
            List<assisted_domain> a1 = new List<assisted_domain>();
            foreach (var item in al)
            {
                a1.Add(convertassisteddomainentitytoassisteddomaintable(item));
            }
            return a1;
        }
    }
}
