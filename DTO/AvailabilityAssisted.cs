using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace DTO
{
   public class AvailabilityAssisted
    {

        public int code_availability_assisted { get; set; }
        public int code_availability { get; set; }
        public string id_assisted { get; set; }

        public static AvailabilityAssisted convertavailabilityassistedtabletoavailabilityassistedentity(assisted_availability a)
         {
            AvailabilityAssisted a1 = new AvailabilityAssisted()
                {
                    code_availability = a.code_availability,
                    code_availability_assisted = a.code_availability_assisted,
                    id_assisted = a.id_assisted
                };
                return a1;
            }
            public static assisted_availability convertavailabilityassistedentitytoavailabilityassistedtable(AvailabilityAssisted a)
            {
                assisted_availability a1 = new assisted_availability()
                {
                    code_availability = a.code_availability,
                    code_availability_assisted = a.code_availability_assisted,
                    id_assisted = a.id_assisted
                };
                return a1;
            }
            public static List<AvailabilityAssisted> convertavailabilityassistedtabletolistavailabilityassistedentity(List<assisted_availability> al)
            {
                List<AvailabilityAssisted> a1 = new List<AvailabilityAssisted>();
                foreach (var item in al)
                {
                    a1.Add(convertavailabilityassistedtabletoavailabilityassistedentity(item));
                }
                return a1;
            }
            public static List<assisted_availability> convertavailabilityassistedentitytolistavailabilityassistedtable(List<AvailabilityAssisted> al)
            {
                List<assisted_availability> a1 = new List<assisted_availability>();
                foreach (var item in al)
                {
                    a1.Add(convertavailabilityassistedentitytoavailabilityassistedtable(item));
                }
                return a1;
            }
        }
    }

