using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class City
    {
        public int code_city { get; set; }
        public string name_city { get; set; }

        public static City convertcitytabletocityentity(city c)
        {
            City c1 = new City()
            {
                code_city = c.code_city,
                name_city = c.name_city
            };
            return c1;
        }

        public static city convertcityentitytocitytable(City c)
        {
            city c1 = new city()
            {
                code_city = c.code_city,
                name_city = c.name_city
            };
            return c1;
        }

        public static List<City> convertcitytabletolistcityentity(List<city> cl)
        {
            List<City> c1 = new List<City>();
            foreach (var item in cl)
            {
                c1.Add(convertcitytabletocityentity(item));
            }
            return c1;
        }
        public static List<city> convertcityentitytolistcitytable(List<City> cl)
        {
            List<city> c1 = new List<city>();
            foreach (var item in cl)
            {
                c1.Add(convertcityentitytocitytable(item));
            }
            return c1;
        }
    }
}
