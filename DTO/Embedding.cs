using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Embedding
    {
        public int code_embedding { get; set; }
        public string id_volunteer { get; set; }
        public string id_assisted { get; set; }
        public Nullable<int> code_volunteering { get; set; }

        public static Embedding convertembeddingtabletoembeddingentity(embedding e)
        {
            Embedding e1 = new Embedding()
            {
                id_assisted = e.id_assisted,
                id_volunteer = e.id_volunteer,
                code_volunteering = e.code_volunteering
            };
            return e1;
        }
        public static embedding convertembeddingentitytoembeddingtable(Embedding e)
        {
            embedding e1 = new embedding()
            {
                id_assisted = e.id_assisted,
                id_volunteer = e.id_volunteer,
                code_volunteering = e.code_volunteering
            };
            return e1;
        }
        public static List<Embedding> convertembeddingtabletolistembeddingentity(List<embedding> el)
        {
            List<Embedding> e1 = new List<Embedding>();
            el.ForEach(e => e1.Add(convertembeddingtabletoembeddingentity(e)));
            return e1;
        }
        public static List<embedding> convertembeddingentitytolistembeddingtable(List<Embedding> el)
        {
            List<embedding> e1 = new List<embedding>();
            el.ForEach(e => e1.Add(convertembeddingentitytoembeddingtable(e)));
            return e1;
        }
    }
}
