using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class PersonalStatus
   {
        public int code_status { get; set; }
        public string description { get; set; }

        public static PersonalStatus convertpersonalstatustablepersonalstatusentity(personal_status p)
        {
            PersonalStatus p1 = new PersonalStatus()
            {
                code_status = p.code_status,
                description = p.description
            };
            return p1;
        }
        public static personal_status convertpersonalstatusentitypersonalstatustable(PersonalStatus p)
        {
            personal_status p1 = new personal_status()
            {
                code_status = p.code_status,
                description = p.description
            };
            return p1;
        }
        public static List<PersonalStatus> convertpersonalstatustabletolistpersonalstatusentity(List<personal_status> pl)
        {
            List<PersonalStatus> p1 = new List<PersonalStatus>();
            foreach (var item in pl)
            {
                p1.Add(convertpersonalstatustablepersonalstatusentity(item));
            }
            return p1;
        }
        public static List<personal_status> convertpersonalstatusentitytolistpersonalstatustable(List<PersonalStatus> pl)
        {
            List<personal_status> p1 = new List<personal_status>();
            foreach (var item in pl)
            {
                p1.Add(convertpersonalstatusentitypersonalstatustable(item));
            }
            return p1;
        }
    }
}
