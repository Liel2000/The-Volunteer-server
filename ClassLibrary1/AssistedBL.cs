using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class AssistedBL
    {
        public static Progect_lEntities db = new Progect_lEntities();
        public static List<Assisted> getall()
        {
            List<assisted> assisted = db.assisted.ToList();
            return Assisted.convertassistedtabletolistassistedentity(assisted);
        }
        public static Assisted getBtId(string id_assisted)
        {
            assisted assisted = db.assisted.FirstOrDefault(x => x.id_assisted == id_assisted);
            return Assisted.convertassistedtabletoassistedentity(assisted);
        }
        public static bool AddAssisted(Assisted assisted)
        {
            try
            {
                assisted a = db.assisted.FirstOrDefault(x => x.id_assisted == assisted.id_assisted);
                if (a != null)
                {
                    if (assisted.languages != null)
                    {
                        List<assisted_language> lList = new List<assisted_language>();
                        List<assisted_language> alList = db.assisted_language.Where(x => x.id_assisted == assisted.id_assisted).ToList();
                        foreach (Language item in assisted.languages)
                        {
                            if (item.IsSelected == true)
                            {
                                assisted_language temp = alList.FirstOrDefault(x => x.id_assisted == assisted.id_assisted && x.code_language == item.code_language);
                                if (temp == null)
                                {
                                    assisted_language al = new assisted_language();
                                    al.id_assisted = assisted.id_assisted;
                                    al.code_language = item.code_language;
                                    lList.Add(al);
                                }
                                else
                                    alList.Remove(temp);
                            }
                        }
                        foreach (assisted_language item in lList)
                        {
                            db.assisted_language.Add(item);
                        }
                        foreach (assisted_language item in alList)
                        {
                            db.assisted_language.Remove(item);
                        }
                    }
                    List<assisted_domain> dList = new List<assisted_domain>();
                    List<assisted_domain> adList = db.assisted_domain.Where(x => x.id_assisted == assisted.id_assisted).ToList();
                    if (assisted.volunteeringdomains != null)
                    {
                        foreach (VolunteeringDomain item in assisted.volunteeringdomains)
                        {
                            assisted_domain temp = adList.FirstOrDefault(x => x.id_assisted == assisted.id_assisted && x.code_volunteering == item.code_volunteering);
                            if (temp == null)
                            {
                                assisted_domain ad = new assisted_domain();
                                ad.id_assisted = assisted.id_assisted;
                                ad.code_volunteering = item.code_volunteering;
                                dList.Add(ad);
                            }
                            else
                                adList.Remove(temp);
                        }
                        foreach (assisted_domain item in dList)
                        {
                            db.assisted_domain.Add(item);
                        }
                        foreach (assisted_domain item in adList)
                        {
                            db.assisted_domain.Remove(item);
                        }
                    }
                    if (assisted.availabilitys != null)
                    {
                        List<assisted_availability> aList = new List<assisted_availability>();
                        List<assisted_availability> aaList = db.assisted_availability.Where(x => x.id_assisted == assisted.id_assisted).ToList();
                        foreach (Availability item in assisted.availabilitys)
                        {
                            if (item.IsSelected == true)
                            {
                                assisted_availability temp = aaList.FirstOrDefault(x => x.id_assisted == assisted.id_assisted && x.code_availability == item.code_availability);
                                if (temp == null)
                                {
                                    assisted_availability av = new assisted_availability();
                                    av.id_assisted = assisted.id_assisted;
                                    av.code_availability = item.code_availability;
                                    aList.Add(av);
                                }
                                else
                                    aaList.Remove(temp);
                            }
                        }
                        foreach (assisted_availability item in aList)
                        {
                            db.assisted_availability.Add(item);
                        }
                        foreach (assisted_availability item in aaList)
                        {
                            db.assisted_availability.Remove(item);
                        }
                    }
                    assisted a1 = Assisted.convertassistedentitytoassistedtable(assisted);
                    a.id_assisted = a1.id_assisted;
                    a.first_name = a1.first_name;
                    a.last_name = a1.last_name;
                    a.date_birth = a1.date_birth;
                    a.code_gender = a1.code_gender;
                    a.code_city = a1.code_city;
                    a.code_status = a1.code_status;
                    a.e_mail = a1.e_mail;
                    a.first_name = a1.first_name;
                    a.id_assisted = a1.id_assisted;
                    a.last_name = a1.last_name;
                    a.street = a1.street;
                    a.number_building = a1.number_building;
                    a.number_floor = a1.number_floor;
                    a.number_house = a1.number_house;
                    a.password = a1.password;
                    a.phone = a1.phone;
                    a.postal_code = a1.postal_code;


                }
                else
                {
                    db.assisted.Add(Assisted.convertassistedentitytoassistedtable(assisted));
                    db.SaveChanges();
                    Mail.SendMail(assisted.e_mail, "ברוך הבא למשפחת the volunteers‏", "פרטיך נקלטו במערכת בהצלחה והועברו לטיפול עי מתנדיבנו תודה שבחרת בנו!");


                    List <assisted_language> alList = Assisted.ConvertLanguageEntityListToAssistedLanguage(assisted.languages, assisted.id_assisted);
                    foreach (assisted_language l in alList)
                    {
                        db.assisted_language.Add(l);
                    }
                    List<assisted_availability> AvailabilityList = Assisted.ConvertAvailabilityEntityListToAssistedAvailability(assisted.availabilitys, assisted.id_assisted);
                    foreach (assisted_availability al in AvailabilityList)
                    {
                        db.assisted_availability.Add(al);
                    }
                    if (assisted.volunteeringdomains != null)
                    {
                        List<assisted_domain> dList = new List<assisted_domain>();
                        foreach (VolunteeringDomain item in assisted.volunteeringdomains)
                        {
                            assisted_domain ad = new assisted_domain();
                            ad.id_assisted = assisted.id_assisted;
                            ad.code_volunteering = item.code_volunteering;
                            dList.Add(ad);
                        }
                        foreach (assisted_domain item in dList)
                        {
                            db.assisted_domain.Add(item);
                        }
                    }
                }
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public static List<Assisted> EmbededAssisted1(Volunteer volunteer)
        {
            List<assisted> assisteds = new List<assisted>();
            var domainVolunteer = db.volunteer_domain.Where(vd => vd.id_volunteer == volunteer.id_volunteer).ToList();
            foreach (var item in db.assisted.ToList())
            {
                foreach (var ad in item.assisted_domain)
                {
                    if (domainVolunteer.Find(x => x.code_volunteering == ad.code_volunteering) != null)
                    {
                        if (!assisteds.Contains(item))
                        {
                            assisteds.Add(item);
                        }
                    }
                }
            }
            var avalVolunteer = db.availability_volunteer.Where(av => av.id_volunteer == volunteer.id_volunteer).ToList();
            foreach (var item in assisteds)
            {
                var avalAssisted = db.assisted_availability.Where(x => x.id_assisted == item.id_assisted).ToList();
                for (int i = 0; i < avalVolunteer.Count; i++)
                {
                    if (avalAssisted.Find(x => x.code_availability == avalVolunteer[i].code_availability) == null)
                    {
                        assisteds.Remove(item);
                    }
                }
            }
            var langVolunteer = db.volunteer_language.Where(vl => vl.id_volunteer == volunteer.id_volunteer).ToList();
            foreach (var item in assisteds)
            {
                var langAssisted = db.assisted_language.Where(x => x.id_assisted == item.id_assisted).ToList();
                for (int i = 0; i < langVolunteer.Count; i++)
                {
                    if (langAssisted.Find(x => x.code_language == langVolunteer[i].code_language) == null)
                    {
                        assisteds.Remove(item);
                    }
                }
            }
            assisteds = assisteds.Where(a => a.code_city == volunteer.code_city).ToList();
            return Assisted.convertassistedtabletolistassistedentity(assisteds);
        }
        public static List<EmbeddindAssisted> GetEmbededAssisteds(Volunteer volunteer)
        {
            List<EmbeddindAssisted> assisteds = new List<EmbeddindAssisted>();
            var domainVolunteer = db.volunteer_domain.Where(vd => vd.id_volunteer == volunteer.id_volunteer).ToList();
            var avalVolunteer = db.availability_volunteer.Where(av => av.id_volunteer == volunteer.id_volunteer).ToList();
            var langVolunteer = db.volunteer_language.Where(vl => vl.id_volunteer == volunteer.id_volunteer).ToList();
            var embeddingsVolunteer = db.embedding.Where(e => e.id_volunteer == volunteer.id_volunteer).ToList();
            var flag = false;
            foreach (var assisted in db.assisted.ToList())
            {
                if (volunteer.code_city == assisted.code_city)
                {
                    foreach (var ad in assisted.assisted_domain)
                    {
                        flag = true;
                        if (domainVolunteer.Find(x => x.code_volunteering == ad.code_volunteering) != null)
                        {
                            foreach (var aa in assisted.assisted_availability)
                            {
                                if (avalVolunteer.Find(x => x.code_availability == aa.code_availability) != null)
                                {
                                    foreach (var al in assisted.assisted_language)
                                    {
                                        if (langVolunteer.Find(x => x.code_language == al.code_language) != null)
                                        {
                                            var embeddingAssisted = new EmbeddindAssisted();
                                            embeddingAssisted.id_assisted = assisted.id_assisted;
                                            embeddingAssisted.id_volunteer = volunteer.id_volunteer;
                                            embeddingAssisted.domain = db.volunteering_domain.Where(vd => vd.code_volunteering == ad.code_volunteering).First().domain.description;
                                            embeddingAssisted.volunteering_domain = db.volunteering_domain.Where(vd => vd.code_volunteering == ad.code_volunteering).First().description;
                                            embeddingAssisted.full_name = assisted.first_name + " " + assisted.last_name;
                                            embeddingAssisted.phone = assisted.phone;
                                            embeddingAssisted.email = assisted.e_mail;
                                            var temp = embeddingsVolunteer.FirstOrDefault(ev => ev.id_assisted == assisted.id_assisted && ev.code_volunteering == ad.code_volunteering);
                                            if (temp != null)
                                                embeddingAssisted.isApproved = true;
                                            else
                                                embeddingAssisted.isApproved = false;
                                            if (flag)
                                                assisteds.Add(embeddingAssisted);
                                            flag = false;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return assisteds.Distinct().ToList();
        }
        public static List<Assisted> RemoveAssisted(string id_assisted)
        {
            db.assisted.Remove(db.assisted.FirstOrDefault(x => x.id_assisted == id_assisted));
            db.SaveChanges();
            return Assisted.convertassistedtabletolistassistedentity(db.assisted.ToList());
        }
        public static List<Assisted> EditAssisted(Assisted assisted)
        {
            db.assisted.FirstOrDefault(x => x.id_assisted == assisted.id_assisted).first_name = assisted.first_name;
            db.assisted.FirstOrDefault(x => x.id_assisted == assisted.id_assisted).last_name = assisted.last_name;
            db.assisted.FirstOrDefault(x => x.id_assisted == assisted.id_assisted).date_birth = assisted.date_birth;
            db.assisted.FirstOrDefault(x => x.id_assisted == assisted.id_assisted).code_gender = assisted.code_gender;
            db.assisted.FirstOrDefault(x => x.id_assisted == assisted.id_assisted).code_status = assisted.code_status;
            db.assisted.FirstOrDefault(x => x.id_assisted == assisted.id_assisted).code_city = assisted.code_city;
            db.assisted.FirstOrDefault(x => x.id_assisted == assisted.id_assisted).postal_code = assisted.postal_code;
            db.assisted.FirstOrDefault(x => x.id_assisted == assisted.id_assisted).street = assisted.street;
            db.assisted.FirstOrDefault(x => x.id_assisted == assisted.id_assisted).number_building = assisted.number_building;
            db.assisted.FirstOrDefault(x => x.id_assisted == assisted.id_assisted).number_house = assisted.number_house;
            db.assisted.FirstOrDefault(x => x.id_assisted == assisted.id_assisted).e_mail = assisted.e_mail;
            db.assisted.FirstOrDefault(x => x.id_assisted == assisted.id_assisted).number_floor = assisted.number_floor;
            db.assisted.FirstOrDefault(x => x.id_assisted == assisted.id_assisted).phone = assisted.phone;
            db.assisted.FirstOrDefault(x => x.id_assisted == assisted.id_assisted).password = assisted.password;
            db.SaveChanges();
            return Assisted.convertassistedtabletolistassistedentity(db.assisted.ToList());
        }
        public static bool SendMessagesToAssisteds(List<EmbeddindAssisted> embeddindAssisteds)
        {
            try
            {
                List<string> emails = new List<string>();
                var vEmail = db.volunteer.ToList().FirstOrDefault(v => v.id_volunteer == embeddindAssisteds[0].id_volunteer).e_mail;
                embeddindAssisteds.ForEach(a => emails.Add(a.email));
                List<Embedding> embeddings = new List<Embedding>();
                embeddindAssisteds.ForEach(a =>
                {
                    Embedding embedding = new Embedding();
                    embedding.id_assisted = a.id_assisted;
                    embedding.id_volunteer = a.id_volunteer;
                    embedding.code_volunteering = db.volunteering_domain.FirstOrDefault(vd => vd.description == a.volunteering_domain).code_volunteering;

                    embeddings.Add(embedding);
                });
                db.embedding.AddRange(Embedding.convertembeddingentitytolistembeddingtable(embeddings));
                db.SaveChanges();
                string body = " השיבוץ בוצע בהצלחה להלן פרטי התקשרות עם הנעזר/ת "+ " ";
                foreach (var item in embeddindAssisteds)
                {
                    body = body + item.full_name +"  "+ "פלאפון:" + item.phone + "  "+
                        "מייל:"  + item.email + "  " + "בתחום ההתנדבות:  "  + item.domain + " " + item.volunteering_domain;
                }
                Mail.SendMail(vEmail, "אשרייך!", body);
                string id = embeddindAssisteds.First().id_volunteer;
                volunteer v1 = db.volunteer.First(x => x.id_volunteer == id);
                string body1 = "מצאנו לך את המתנדב/ת המתאים להלן פרטי התקשרות עם המתנדב/ת " + "  " + v1.firstName_volunteer + "   " + v1.lastName_volunteer + "   " + "פלאפון:" + v1.phone + 
                    "  " + "מייל:"  + v1.e_mail ;
                return Mail.SendMailForGroup(emails, "מצאנו...", body1);

            }
            catch(Exception e)
            {
                return false;
            }
        }
        public static List<PersonalStatus> GetPersonalStatuses()
        {
            Progect_lEntities db = new Progect_lEntities();
            List<PersonalStatus> list = new List<PersonalStatus>();
            foreach (var item in db.personal_status)
            {
                list.Add(new PersonalStatus { code_status = item.code_status, description = item.description });
            }
            return list;
        }
        public static List<Gender> GetGender()
        {
            Progect_lEntities db = new Progect_lEntities();
            List<Gender> list1 = new List<Gender>();
            foreach (var item in db.gender)
            {
                list1.Add(new Gender { code_gender = item.code_gender, description = item.description });
            }
            return list1;
        }
        public static List<Language> GetLanguageAssisted(string assisted_id)
        {
            Progect_lEntities db = new Progect_lEntities();
            List<Language> list2 = new List<Language>();
            List<int> myLanguages = db.assisted_language.Where(x => x.id_assisted == assisted_id).Select(y => y.code_language).ToList();
            foreach (var item in db.language)
            {
                bool isSelected = false;
                if (myLanguages.Contains(item.code_language))
                {
                    isSelected = true;
                }
                list2.Add(new Language { code_language = item.code_language, name_language = item.name_language, IsSelected = isSelected });
            }
            return list2;
        }
        public static List<Language> GetLanguage()
        {
            Progect_lEntities db = new Progect_lEntities();
            List<Language> list2 = new List<Language>();
            foreach (var item in db.language)
            {
                list2.Add(new Language { code_language = item.code_language, name_language = item.name_language, IsSelected = false });
            }
            return list2;
        }
        public static List<City> GetCity()
        {
            Progect_lEntities db = new Progect_lEntities();
            List<City> list3 = new List<City>();
            foreach (var item in db.city)
            {
                list3.Add(new City { code_city = item.code_city, name_city = item.name_city });
            }
            return list3;
        }
        public static List<Days> GetDays()
        {
            Progect_lEntities db = new Progect_lEntities();
            List<Days> list4 = new List<Days>();
            foreach (var item in db.days)
            {
                list4.Add(new Days { code_day = item.code_day, description = item.description });
            }
            return list4;
        }
        public static List<Shift> GetShift()
        {
            Progect_lEntities db = new Progect_lEntities();
            List<Shift> list5 = new List<Shift>();
            foreach (var item in db.shifts)
            {
                list5.Add(new Shift { code_shift = item.code_shift, description = item.description });
            }
            return list5;
        }
        public static List<VolunteeringDomain> GetVolunteeringDomain(string assisted_id)
        {
            Progect_lEntities db = new Progect_lEntities();
            List<VolunteeringDomain> ListVolunteeringDomain = new List<VolunteeringDomain>();
            List<int> myVolunteeringDomain = db.assisted_domain.Where(x => x.id_assisted == assisted_id).Select(y => y.code_volunteering).ToList();

            foreach (var item in db.volunteering_domain)
            {
                bool isSelected = false;
                if (myVolunteeringDomain.Contains(item.code_volunteering))
                {
                    isSelected = true;
                }
                ListVolunteeringDomain.Add(new VolunteeringDomain { code_domain = item.code_domain, description=item.description, code_volunteering = item.code_volunteering, IsSelected = isSelected });
            }
            return ListVolunteeringDomain;
        }
        public static List<Availability> GetAvailabilitys()
        {
            List<Availability> availabilitys = new List<Availability>();
            var days = db.days.ToList();
            var shifts = db.shifts.ToList();
            foreach (availability item in db.availability)
            {
                availabilitys.Add(new Availability
                {
                    code_day = item.code_day,
                    day_description = days.FirstOrDefault(x => x.code_day == item.code_day).description,
                    shift_description = shifts.FirstOrDefault(x => x.code_shift == item.code_shift).description,
                    code_shift = item.code_shift,
                    IsSelected = false
                });
            }
            return availabilitys;
        }
        public static List<Availability> GetAvailability()
        {
            Progect_lEntities db = new Progect_lEntities();
            List<Availability> lista = new List<Availability>();
            foreach (var item in db.availability)
            {
                lista.Add(new Availability { code_availability = item.code_availability, code_day = item.code_day, code_shift = item.code_shift, IsSelected = false });
            }
            return lista;
        }
        public static List<Availability> GetAvailabilityAssisted(string assisted_id)
        {
            Progect_lEntities db = new Progect_lEntities();
            List<Availability> ListAvailabilities = new List<Availability>();
            List<int> myAvailability = db.assisted_availability.Where(x => x.id_assisted == assisted_id).Select(y => y.code_availability).ToList();

            foreach (var item in db.availability)
            {
                bool isSelected = false;
                if (myAvailability.Contains(item.code_availability))
                {
                    isSelected = true;
                }
                ListAvailabilities.Add(new Availability { code_availability = item.code_availability, code_day = item.code_day, code_shift = item.code_shift, IsSelected = isSelected });
            }
            return ListAvailabilities;
        }
    }
}
