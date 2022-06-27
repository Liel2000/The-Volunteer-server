using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Days
    {

        public int code_day { get; set; }
        public string description { get; set; }

        public static Days convertdaytabletodayentity(days d)
        {
            Days d1 = new Days()
            {
                code_day = d.code_day,
                description = d.description
            };
            return d1;
        }
        public static days convertdayentitytodaytable(Days d)
        {
            days d1 = new days()
            {
                code_day = d.code_day,
                description = d.description
            };
            return d1;
        }
        public static List<Days> convertdaytabletolistdayentity(List<days> dl)
        {
            List<Days> d1 = new List<Days>();
            foreach (var item in dl)
            {
                d1.Add(convertdaytabletodayentity(item));
            }
            return d1;
        }
        public static List<days> convertdayentitytolistdaytable(List<Days> dl)
        {
            List<days> d1 = new List<days>();
            foreach (var item in dl)
            {
                d1.Add(convertdayentitytodaytable(item));
            }
            return d1;
        }
    }
}
