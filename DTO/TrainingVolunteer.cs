using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class TrainingVolunteer
   {
        public int code_training_volunteer { get; set; }
        public int code_training { get; set; }
        public string id_volunteer { get; set; }


        public static TrainingVolunteer converttrainingvolunteertabletotrainingvolunteerentity(training_volunteer t)
        {
            TrainingVolunteer t1 = new TrainingVolunteer()
            {
                code_training = t.code_training,
                code_training_volunteer = t.code_training_volunteer,
                id_volunteer=t.id_volunteer
            };
            return t1;
        }
        public static training_volunteer converttrainingvolunteerentitytotrainingvolunteertable(TrainingVolunteer t)
        {
            training_volunteer t1 = new training_volunteer()
            {
                code_training = t.code_training,
                code_training_volunteer = t.code_training_volunteer,
                id_volunteer = t.id_volunteer
            };
            return t1;
        }
        public static List<TrainingVolunteer> converttrainingvolunteertabletolisttrainingvolunteerentity(List<training_volunteer> tl)
        {
            List<TrainingVolunteer> t1 = new List<TrainingVolunteer>();
            foreach (var item in tl)
            {
                t1.Add(converttrainingvolunteertabletotrainingvolunteerentity(item));
            }
            return t1;
        }
        public static List<training_volunteer> converttreiningvolunteerentitytolisttrainingvolunteertable(List<TrainingVolunteer> tl)
        {
            List<training_volunteer> t1 = new List<training_volunteer>();
            foreach (var item in tl)
            {
                t1.Add(converttrainingvolunteerentitytotrainingvolunteertable(item));
            }
            return t1;
        }
    }
}
