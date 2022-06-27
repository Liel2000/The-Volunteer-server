using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Gender
    {
        public int code_gender { get; set; }
        public string description { get; set; }

        public static Gender convertgendertabletogenderentity(gender g)
        {
            Gender g1 = new Gender()
            {
                code_gender = g.code_gender,
                description = g.description
            };
            return g1;
        }

        public static gender convertgenderentitytogendertable(Gender g)
        {
            gender g1 = new gender()
            {
                code_gender = g.code_gender,
                description = g.description
            };
            return g1;
        }
        public static List<Gender> convertgendertabletolistgenderentity(List<gender> gl)
        {
            List<Gender> g1 = new List<Gender>();
            foreach (var item in gl)
            {
                g1.Add(convertgendertabletogenderentity(item));
            }
            return g1;
        }
        public static List<gender> convertgenderentitytolistgendertable(List<Gender> gl)
        {
            List<gender> g1 = new List<gender>();
            foreach (var item in gl)
            {
                g1.Add(convertgenderentitytogendertable(item));
            }
            return g1;
        }
    }
}
