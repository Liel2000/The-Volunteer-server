using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class AvailabilityVolunteer
   {
        public int code_availability_volunteer { get; set; }
        public int code_availability { get; set; }
        public string id_volunteer { get; set; }

        public static AvailabilityVolunteer convertavailabilityvolunteertabletoavailabilityvolunteerentity(availability_volunteer a)
        {
            AvailabilityVolunteer a1 = new AvailabilityVolunteer()
            {
                code_availability = a.code_availability,
                code_availability_volunteer = a.code_availability_volunteer,
                id_volunteer = a.id_volunteer
            };
            return a1;
        }
        public static availability_volunteer convertavailabilityvolunteerentitytoavailabilityvolunteertable(AvailabilityVolunteer a)
        {
            availability_volunteer a1 = new availability_volunteer()
            {
                code_availability = a.code_availability,
                code_availability_volunteer = a.code_availability_volunteer,
                id_volunteer = a.id_volunteer
            };
            return a1;
        }
        public static List<AvailabilityVolunteer> convertavailabilityvolunteertabletolistavailabilityvolunteerentity(List<availability_volunteer> al)
        {
            List<AvailabilityVolunteer> a1 = new List<AvailabilityVolunteer>();
            foreach (var item in al)
            {
                a1.Add(convertavailabilityvolunteertabletoavailabilityvolunteerentity(item));
            }
            return a1;
        }
        public static List<availability_volunteer> convertavailabilityvolunteerentitytolistavailabilityvolunteertable(List<AvailabilityVolunteer> al)
        {
            List<availability_volunteer> a1 = new List<availability_volunteer>();
            foreach (var item in al)
            {
                a1.Add(convertavailabilityvolunteerentitytoavailabilityvolunteertable(item));
            }
            return a1;
        }
    }
}
