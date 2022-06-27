using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
using System.Linq.Expressions;

namespace BL
{
    public class VolunteerBL
    {
        public static Progect_lEntities db = new Progect_lEntities();
        public static List<Volunteer> getall()
        {
            List<volunteer> volunteer = db.volunteer.ToList();
            return Volunteer.convertvolunteertabletolistvolunteerentity(volunteer);
        }
        public static Volunteer getById(string id_volunteer)
        {
            volunteer volunteer = db.volunteer.FirstOrDefault(x => x.id_volunteer == id_volunteer);
            return Volunteer.convertvolunteertabletovolunteerentity(volunteer);
        }
        public static bool AddVolunteer(Volunteer volunteer)
        {
            try
            {
                volunteer v = db.volunteer.FirstOrDefault(x => x.id_volunteer == volunteer.id_volunteer);
                if (v!=null)
                {
                    List<volunteer_domain> dList = new List<volunteer_domain>();
                    List<volunteer_domain> vdList = db.volunteer_domain.Where(x => x.id_volunteer == volunteer.id_volunteer).ToList();
                   if(volunteer.volunteeringdomains!=null)
                    {
                        foreach (VolunteeringDomain item in volunteer.volunteeringdomains)
                        {
                            volunteer_domain temp = vdList.FirstOrDefault(x => x.id_volunteer == volunteer.id_volunteer && x.code_volunteering == item.code_volunteering);
                            if (temp == null)
                            {
                                volunteer_domain vvo1 = new volunteer_domain();
                                vvo1.id_volunteer = volunteer.id_volunteer;
                                vvo1.code_volunteering = item.code_volunteering;
                                dList.Add(vvo1);
                            }
                            else
                                vdList.Remove(temp);
                        }
                        foreach (volunteer_domain item in dList)
                        {
                            db.volunteer_domain.Add(item);
                        }
                        foreach (volunteer_domain item in vdList)
                        {
                            db.volunteer_domain.Remove(item);
                        }
                   }

                    List<volunteer_language> lList = new List<volunteer_language>();
                    List<volunteer_language> vlList = db.volunteer_language.Where(x => x.id_volunteer == volunteer.id_volunteer).ToList();
                    foreach (Language item in volunteer.languages)
                    {
                        if(item.IsSelected==true)
                        {
                            volunteer_language temp = vlList.FirstOrDefault(x => x.id_volunteer == volunteer.id_volunteer && x.code_language == item.code_language);
                            if (temp == null)
                            {
                                volunteer_language vvo = new volunteer_language();
                                vvo.id_volunteer = volunteer.id_volunteer;
                                vvo.code_language = item.code_language;
                                lList.Add(vvo);
                            }
                            else
                                vlList.Remove(temp);
                        }
                    }
                    foreach (volunteer_language item in lList)
                    {
                        db.volunteer_language.Add(item);
                    }
                    foreach (volunteer_language item in vlList)
                    {
                        db.volunteer_language.Remove(item);
                    }

                    List<availability_volunteer> aList = new List<availability_volunteer>();
                    List<availability_volunteer> vaList = db.availability_volunteer.Where(x => x.id_volunteer == volunteer.id_volunteer).ToList();
                    foreach (Availability item in volunteer.availabilitys)
                    {
                        if (item.IsSelected == true)
                        {
                            availability_volunteer temp = vaList.FirstOrDefault(x => x.id_volunteer == volunteer.id_volunteer && x.code_availability == item.code_availability);
                            if (temp == null)
                            {
                                availability_volunteer vvo = new availability_volunteer();
                                vvo.id_volunteer = volunteer.id_volunteer;
                                vvo.code_availability = item.code_availability;
                                aList.Add(vvo);
                            }
                            else
                                vaList.Remove(temp);
                        }
                    }
                    foreach (availability_volunteer item in aList)
                    {
                        db.availability_volunteer.Add(item);
                    }
                    foreach (availability_volunteer item in vaList)
                    {
                        db.availability_volunteer.Remove(item);
                    }

                    volunteer v1 = Volunteer.convertvolunteerentitytovolunteertable(volunteer);
                   
                    v.bulding_number = v1.bulding_number;
                    v.code_city = v1.code_city;
                    v.code_gender = v1.code_gender;
                    v.code_service = v1.code_service;
                    v.code_status = v1.code_status;
                    v.date_of_birth = v1.date_of_birth;
                    v.e_mail = v1.e_mail;
                    v.firstName_volunteer = v1.firstName_volunteer;
                    v.house_number = v1.house_number;
                    v.id_volunteer = v1.id_volunteer;
                    v.firstName_volunteer = v1.firstName_volunteer;
                    v.lastName_volunteer = v1.lastName_volunteer;
                    v.date_of_birth = v1.date_of_birth;
                    v.code_gender = v1.code_gender;
                    v.code_status = v1.code_status;
                    v.code_city = v1.code_city;
                    v.street = v1.street;
                    v.postal_code = v1.postal_code;
                    v.number_floor = v1.number_floor;
                    v.house_number = v1.house_number;
                    v.bulding_number = v1.bulding_number;
                    v.password = v1.password;
                    v.phone = v1.phone;
                    v.e_mail = v1.e_mail;
                    v.code_service = v1.code_service;
                    v.description_service = v1.description_service;
                    v.release_date = v1.release_date;
                    v.code_car_license = v1.code_car_license;
                    v.code_weapons_license = v1.code_weapons_license;
                    v.validityc = v1.validityc;
                    v.validityw = v1.validityw;
                    v.password = v1.password;

                    db.SaveChanges();
                }
                else
                {
                    db.volunteer.Add(Volunteer.convertvolunteerentitytovolunteertable(volunteer));
                    db.SaveChanges();
                    Mail.SendMail(volunteer.e_mail, "ברוך הבא לקהילת המתנדבים!", "פרטיך נרשמו במערכת בהצלחה תודה שהצטרפת אלינו!");

                    if (volunteer.volunteeringdomains!=null)
                    {
                        List<volunteer_domain> dList = new List<volunteer_domain>();
                        foreach (VolunteeringDomain item in volunteer.volunteeringdomains)
                        {
                            volunteer_domain vvo = new volunteer_domain();
                            vvo.id_volunteer = volunteer.id_volunteer;
                            vvo.code_volunteering = item.code_volunteering;
                            dList.Add(vvo);
                        }
                        foreach (volunteer_domain item in dList)
                        {
                            db.volunteer_domain.Add(item);
                        }
                    }

                    if (volunteer.languages != null)
                    {
                        List<volunteer_language> vlList = Volunteer.ConvertLanguageEntityListToVolunteerLanguage(volunteer.languages, volunteer.id_volunteer);
                        foreach (volunteer_language l in vlList)
                        {
                            db.volunteer_language.Add(l);
                        }
                    }

                    if (volunteer.availabilitys != null)
                    {
                        List<availability_volunteer> AvailabilityList = Volunteer.ConvertAvailabilityEntityListToVolunteerAvailability(volunteer.availabilitys, volunteer.id_volunteer);
                        foreach (availability_volunteer a in AvailabilityList)
                        {
                            db.availability_volunteer.Add(a);
                        }
                    }
                    db.SaveChanges();
                }
            }

            catch (Exception e)
            {
                return false;
            }

            return true;
        }



        public static List<Volunteer> RemoveVolunteer(string id_volunteer)
        {
            db.volunteer.Remove(db.volunteer.FirstOrDefault(x => x.id_volunteer == id_volunteer));
            db.SaveChanges();
            return Volunteer.convertvolunteertabletolistvolunteerentity(db.volunteer.ToList());
        }
        public static List<Volunteer> EditVolunteer(Volunteer volunteer)
        {   db.volunteer.FirstOrDefault(x => x.id_volunteer == volunteer.id_volunteer).firstName_volunteer = volunteer.firstName_volunteer;
            db.volunteer.FirstOrDefault(x => x.id_volunteer == volunteer.id_volunteer).lastName_volunteer = volunteer.lastName_volunteer;
            db.volunteer.FirstOrDefault(x => x.id_volunteer == volunteer.id_volunteer).date_of_birth = volunteer.date_of_birth;
            db.volunteer.FirstOrDefault(x => x.id_volunteer == volunteer.id_volunteer).code_gender = volunteer.code_gender;
            db.volunteer.FirstOrDefault(x => x.id_volunteer == volunteer.id_volunteer).code_service = volunteer.code_service;
            db.volunteer.FirstOrDefault(x => x.id_volunteer == volunteer.id_volunteer).code_status = volunteer.code_status;
            db.volunteer.FirstOrDefault(x => x.id_volunteer == volunteer.id_volunteer).code_city = volunteer.code_city;
            db.volunteer.FirstOrDefault(x => x.id_volunteer == volunteer.id_volunteer).street = volunteer.street;
            db.volunteer.FirstOrDefault(x => x.id_volunteer == volunteer.id_volunteer).bulding_number = volunteer.bulding_number;
            db.volunteer.FirstOrDefault(x => x.id_volunteer == volunteer.id_volunteer).house_number = volunteer.house_number;
            db.volunteer.FirstOrDefault(x => x.id_volunteer == volunteer.id_volunteer).number_floor = volunteer.number_floor;
            db.volunteer.FirstOrDefault(x => x.id_volunteer == volunteer.id_volunteer).postal_code = volunteer.postal_code;
            db.volunteer.FirstOrDefault(x => x.id_volunteer == volunteer.id_volunteer).e_mail = volunteer.e_mail;
            db.volunteer.FirstOrDefault(x => x.id_volunteer == volunteer.id_volunteer).phone = volunteer.phone;
            db.volunteer.FirstOrDefault(x => x.id_volunteer == volunteer.id_volunteer).password = volunteer.password;
            db.SaveChanges();
            return Volunteer.convertvolunteertabletolistvolunteerentity(db.volunteer.ToList());
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
        public static List<CarLicense> GetCarLicense()
        {
            Progect_lEntities db = new Progect_lEntities();
            List<CarLicense> list2 = new List<CarLicense>();
            foreach (var item in db.car_license)
            {
                list2.Add(new CarLicense { code_car_license = item.code_car_license, description = item.description });
            }
            return list2;
        }

        public static List<WeaponsLicense> GetWeaponsLicense()
        {
            Progect_lEntities db = new Progect_lEntities();
            List<WeaponsLicense> list3 = new List<WeaponsLicense>();
            foreach (var item in db.weapons_license)
            {
                list3.Add(new WeaponsLicense { code_weapons_license = item.code_weapons_license, description = item.description });
            }
            return list3;
        }
        public static List<VolunteeringDomain> GetVolunteeringDomain(string volunteer_id)
        {
            Progect_lEntities db = new Progect_lEntities();
            List<VolunteeringDomain> ListVolunteeringDomain = new List<VolunteeringDomain>();
            List<int> myVolunteeringDomain = db.volunteer_domain.Where(x => x.id_volunteer == volunteer_id).Select(y => y.code_volunteering).ToList();

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
        public static List<Availability> GetAvailabilityVolunteer(string volunteer_id)
        {
            Progect_lEntities db = new Progect_lEntities();
            List<Availability> ListAvailabilities = new List<Availability>();
            List<int> myAvailability = db.availability_volunteer.Where(x => x.id_volunteer == volunteer_id).Select(y => y.code_availability).ToList();
            
            foreach (var item in db.availability)
            {
                bool isSelected = false;
                if (myAvailability.Contains(item.code_availability))
                {
                    isSelected = true;
                }
                ListAvailabilities.Add(new Availability { code_availability = item.code_availability, code_day=item.code_day, code_shift=item.code_shift, IsSelected = isSelected });
            }
            return ListAvailabilities;
        }
        public static List<Availability> GetAvailability()
        {
            Progect_lEntities db = new Progect_lEntities();
            List<Availability> lista = new List<Availability>();
            foreach (var item in db.availability)
            {
                lista.Add(new Availability { code_availability = item.code_availability, code_day = item.code_day, code_shift=item.code_shift, IsSelected = false });
            }
            return lista;
        }
        public static List<Days> GetDays()
        {
            Progect_lEntities db = new Progect_lEntities();
            List<Days> list4 = new List<Days>();
            foreach (var item in db.days)
            {
                list4.Add(new Days { code_day = item.code_day, description = item.description});
            }
            return list4;
        }
        public static List<Shift> GetShift()
        {
            Progect_lEntities db = new Progect_lEntities();
            List<Shift> list8 = new List<Shift>();
            foreach (var item in db.shifts)
            {
                list8.Add(new Shift { code_shift = item.code_shift, description = item.description });
            }
            return list8;
        }
        public static List<Language> GetLanguageVolunteer(string volunteer_id)
        {
            Progect_lEntities db = new Progect_lEntities();
            List<Language> list5 = new List<Language>();
            List<int> myLanguages = db.volunteer_language.Where(x => x.id_volunteer == volunteer_id).Select(y => y.code_language).ToList();
            foreach (var item in db.language)
            {
                bool isSelected = false;
                if (myLanguages.Contains(item.code_language))
                {
                    isSelected = true;
                }
                list5.Add(new Language { code_language = item.code_language, name_language = item.name_language, IsSelected = isSelected });
            }
            return list5;
        }
        public static List<Language> GetLanguage()
        {
            Progect_lEntities db = new Progect_lEntities();
            List<Language> list5 = new List<Language>();
            foreach (var item in db.language)
            {
             
                list5.Add(new Language { code_language = item.code_language, name_language = item.name_language, IsSelected=false });
            }
            return list5;
        }

        public static List<Availability> GetAvailabilitys()
        {
            List<Availability> availabilitys = new List<Availability>();
            var days = db.days.ToList();
            var shifts = db.shifts.ToList();
            foreach (availability item in db.availability)
            {
                availabilitys.Add(new Availability {
                    code_day = item.code_day,
                    day_description= days.FirstOrDefault(x=>x.code_day==item.code_day).description,
                    shift_description= shifts.FirstOrDefault(x => x.code_shift == item.code_shift).description,
                    code_shift = item.code_shift,
                    IsSelected = false });
            }
            return availabilitys;
        }

        public static List<City> GetCity()
        {
            Progect_lEntities db = new Progect_lEntities();
            List<City> list6 = new List<City>();
            foreach (var item in db.city)
            {
                list6.Add(new City { code_city = item.code_city, name_city = item.name_city });
            }
            return list6;
        }
        public static List<Services> GetServices()
        {
            Progect_lEntities db = new Progect_lEntities();
            List<Services> list7 = new List<Services>();
            foreach (var item in db.services)
            {
                list7.Add(new Services { code_service = item.code_service, description = item.description });
            }
            return list7;
        }
    }
}
