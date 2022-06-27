using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Training
    {
        public int code_training { get; set; }
        public string description { get; set; }

        public static Training converttrainingtabletotrainingentity(training t)
        {
            Training t1 = new Training()
            {
                code_training = t.code_training,
                description = t.description
            };
            return t1;
        }
        public static training converttrainingentitytotrainingtable(Training t)
        {
            training t1 = new training()
            {
                code_training = t.code_training,
                description = t.description
            };
            return t1;
        }
        public static List<Training> converttrainingtabletolisttrainingentity(List<training> tl)
        {
            List<Training> t1 = new List<Training>();
            foreach (var item in tl)
            {
                t1.Add(converttrainingtabletotrainingentity(item));
            }
            return t1;
        }
        public static List<training> converttreiningentitytolisttrainingtable(List<Training> tl)
        {
            List<training> t1 = new List<training>();
            foreach (var item in tl)
            {
                t1.Add(converttrainingentitytotrainingtable(item));
            }
            return t1;
        }
    }
}
