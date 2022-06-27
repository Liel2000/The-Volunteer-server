using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Shift
    {
        
   
        public int code_shift { get; set; }
        public string description { get; set; }


        public static Shift convertshifttabletoshiftentity(shifts s)
        {
            Shift s1 = new Shift()
            {
                code_shift = s.code_shift,
                description = s.description
            };
            return s1;
        }
        public static shifts convertshiftentitytoshifttable(Shift s)
        {
            shifts s1 = new shifts()
            {
                code_shift = s.code_shift,
                description = s.description
            };
            return s1;
        }
        public static List<Shift> convertshifttabletolistshiftentity(List<shifts> sl)
        {
            List<Shift> s1 = new List<Shift>();
            foreach (var item in sl)
            {
                s1.Add(convertshifttabletoshiftentity(item));
            }
            return s1;
        }
        public static List<shifts> convertshiftentitytolistshifttable(List<Shift> sl)
        {
            List<shifts> s1 = new List<shifts>();
            foreach (var item in sl)
            {
                s1.Add(convertshiftentitytoshifttable(item));
            }
            return s1;
        }
    }
}
