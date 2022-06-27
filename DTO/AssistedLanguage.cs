using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public  class AssistedLanguage
   {
        public int code_assisted_language { get; set; }
        public int code_language { get; set; }
        public string id_assisted { get; set; }


        public static AssistedLanguage convertassistedlanguagetabletoassistedlanguageentity(assisted_language a)
        {
            AssistedLanguage a1 = new AssistedLanguage()
            {
                code_assisted_language = a.code_assisted_language,
                code_language = a.code_language,
                id_assisted = a.id_assisted
            };
            return a1;
        }

        public static assisted_language convertassistedlanguageentitytoassistedlanguagetable(AssistedLanguage a)
        {
            assisted_language a1 = new assisted_language()
            {
                code_assisted_language = a.code_assisted_language,
                code_language = a.code_language,
                id_assisted = a.id_assisted
            };
            return a1;
        }

        public static List<AssistedLanguage> convertassistedlanguagetabletolistassistedlanguageentity(List<assisted_language> al)
        {
            List<AssistedLanguage> a1 = new List<AssistedLanguage>();
            foreach (var item in al)
            {
                a1.Add(convertassistedlanguagetabletoassistedlanguageentity(item));
            }
            return a1;
        }
        public static List<assisted_language> convertassistedlanguageentitytolistassistedlanguagetable(List<AssistedLanguage> al)
        {
            List<assisted_language> a1 = new List<assisted_language>();
            foreach (var item in al)
            {
                a1.Add(convertassistedlanguageentitytoassistedlanguagetable(item));
            }
            return a1;
        }
    }
}
