using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class CarLicense
   {
        public int code_car_license { get; set; }
        public string description { get; set; }
        public bool IsSelected { get; set; }

        public static CarLicense convertcarlicensetabletocarlicenseentity(car_license c)
        {
            CarLicense c1 = new CarLicense()
            {
                code_car_license = c.code_car_license,
                description = c.description
            };
            return c1;
        }
        public static car_license convertcarlicenseentitytocarlicensetable(CarLicense c)
        {
            car_license c1 = new car_license()
            {
                code_car_license = c.code_car_license,
                description = c.description
            };
            return c1;
        }
        public static List<car_license> convertcarlicenseentitytolistcarlicensetable(List<CarLicense> al)
        {
            List<car_license> a1 = new List<car_license>();
            foreach (var item in al)
            {
                a1.Add(convertcarlicenseentitytocarlicensetable(item));
            }
            return a1;
        }
        public static List<CarLicense> convertcarlicensetabletolistcarlicenseentity(List<car_license> al)
        {
            List<CarLicense> a1 = new List<CarLicense>();
            foreach (var item in al)
            {
                a1.Add(convertcarlicensetabletocarlicenseentity(item));
            }
            return a1;
        }
    }
}
