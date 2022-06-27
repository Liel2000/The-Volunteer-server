using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class Language
   {
        public int code_language { get; set; }
        public string name_language { get; set; }
        public bool IsSelected { get; set; }



        public static Language convertlanguagetabletolanguageentity(language l)
        {
            Language l1 = new Language()
            {
                code_language = l.code_language,
                name_language = l.name_language
            };
            return l1;
        }
        public static language convertlanguageentitytolanguagetable(Language l)
        {
            language l1 = new language()
            {
                code_language = l.code_language,
                name_language = l.name_language
            };
            return l1;
        }
        public static List<Language> convertvolunteertabletolistvolunteerentity(List<language> ll)
        {
            List<Language> l1 = new List<Language>();
            foreach (var item in ll)
            {
                l1.Add(convertlanguagetabletolanguageentity(item));
            }
            return l1;
        }
        public static List<language> convertvolunteerentitytolistvolunteertable(List<Language> ll)
        {
            List<language> l1 = new List<language>();
            foreach (var item in ll)
            {
                l1.Add(convertlanguageentitytolanguagetable(item));
            }
            return l1;
        }

    }
}
