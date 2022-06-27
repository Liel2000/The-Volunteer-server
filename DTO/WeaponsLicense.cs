using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class WeaponsLicense
    {

        public int code_weapons_license { get; set; }
        public string description { get; set; }
        public bool IsSelected { get; set; }

        public static WeaponsLicense convertweaponslicensetabletoweaponslicenseentity(weapons_license w)
        {
            WeaponsLicense w1 = new WeaponsLicense()
            {
                code_weapons_license = w.code_weapons_license,
                description = w.description

            };
            return w1;
        }
        public static weapons_license convertweaponslicenseentitytoweaponslicensetable(WeaponsLicense w)
        {
            weapons_license w1 = new weapons_license()
            {
                code_weapons_license = w.code_weapons_license,
                description = w.description

            };
            return w1;
        }
        public static List<WeaponsLicense> convertweaponslicensetabletolistweaponslicenseentity(List<weapons_license> wl)
        {
            List<WeaponsLicense> w1 = new List<WeaponsLicense>();
            foreach (var item in wl)
            {
                w1.Add(convertweaponslicensetabletoweaponslicenseentity(item));
            }
            return w1;
        }
        public static List<weapons_license> convertweaponslicenseentitytolistweaponslicensetable(List<WeaponsLicense> wl)
        {
            List<weapons_license> w1 = new List<weapons_license>();
            foreach (var item in wl)
            {
                w1.Add(convertweaponslicenseentitytoweaponslicensetable(item));
            }
            return w1;
        }

    }
}
