using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Availability
    {
        public int code_availability { get; set; }
        public int code_day { get; set; }
        public string day_description { get; set; }
        public int code_shift { get; set;  }
        public string shift_description { get; set; }
        public bool IsSelected { get; set; }

        public static Availability convertavailabilitytabletoavailabilityentity(availability a)
        {
            Availability a1 = new Availability()
            {
                code_availability = a.code_availability,
                code_day = a.code_day,
                code_shift = a.code_shift,
                
            };
            return a1;
        }
        public static availability convertavailabilityentitytoavailabilitytable(Availability a)
        {
            availability a1 = new availability()
            {
                code_availability = a.code_availability,
                code_day = a.code_day,
                code_shift = a.code_shift
            };
            return a1;
        }
        public static List<Availability> convertavailabilitytabletolistavailabilityentity(List<availability> al)
        {
            List<Availability> a1 = new List<Availability>();
            foreach (var item in al)
            {
                a1.Add(convertavailabilitytabletoavailabilityentity(item));
            }
            return a1;
        }
        public static List<availability> convertavailabilityentitytolistavailabilitytable(List<Availability> al)
        {
            List<availability> a1 = new List<availability>();
            foreach (var item in al)
            {
                a1.Add(convertavailabilityentitytoavailabilitytable(item));
            }
            return a1;
        }
    }
}
