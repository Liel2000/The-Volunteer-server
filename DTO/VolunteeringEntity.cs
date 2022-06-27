using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace DTO
{
    public class VolunteeringEntity
    {
        public int code_Volunteering { get; set; }
        public string name_Volunteering { get; set; }
        public string Details { get; set; }
        public Nullable<int> code_domain { get; set; }

        public static VolunteeringEntity ConvertvolunteeringTableToVolunteeringEntity(volunteering volunteering)
        {
            VolunteeringEntity volunteering1 = new VolunteeringEntity
            {
                code_Volunteering = volunteering.code_Volunteering,
                name_Volunteering = volunteering.name_Volunteering,
                Details = volunteering.Details,
                code_domain = volunteering.code_domain
                
    };
            return volunteering1;
        }

        public static volunteering ConvertVolunteeringEntityTovolunteeringTable(VolunteeringEntity volunteering)
        {
            volunteering volunteering1 = new volunteering
            {
                code_Volunteering = volunteering.code_Volunteering,

                name_Volunteering = volunteering.name_Volunteering,
                Details = volunteering.Details,
                code_domain = volunteering.code_domain
            };
            return volunteering1;
        }


        public static List<VolunteeringEntity> ConvertvolunteeringTableToListVolunteeringEntity(List<volunteering> volunteerings)
        {
            List<VolunteeringEntity> volunteerings1 = new List<VolunteeringEntity>();
            foreach(var item in volunteerings)
            {
                volunteerings1.Add(ConvertvolunteeringTableToVolunteeringEntity(item));
            }
            return volunteerings1;
        }



        public static List<volunteering> ConvertVolunteeringEntityToListvolunteeringTable(List<VolunteeringEntity> volunteerings)
        {
            List<volunteering> volunteerings1 = new List<volunteering>();
            foreach (var item in volunteerings)
            {
                volunteerings1.Add(ConvertVolunteeringEntityTovolunteeringTable(item));
            }
            return volunteerings1;
        }
        //תודה!
       //סבבה את יכולה לנתק
    }
}
