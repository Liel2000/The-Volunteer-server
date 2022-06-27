//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class volunteer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public volunteer()
        {
            this.availability_volunteer = new HashSet<availability_volunteer>();
            this.training_volunteer = new HashSet<training_volunteer>();
            this.volunteer_domain = new HashSet<volunteer_domain>();
            this.volunteer_language = new HashSet<volunteer_language>();
            this.embedding = new HashSet<embedding>();
        }
    
        public string id_volunteer { get; set; }
        public string firstName_volunteer { get; set; }
        public string lastName_volunteer { get; set; }
        public Nullable<System.DateTime> date_of_birth { get; set; }
        public Nullable<int> code_gender { get; set; }
        public Nullable<int> code_status { get; set; }
        public Nullable<int> code_city { get; set; }
        public string street { get; set; }
        public string postal_code { get; set; }
        public Nullable<int> house_number { get; set; }
        public Nullable<int> bulding_number { get; set; }
        public Nullable<int> number_floor { get; set; }
        public string e_mail { get; set; }
        public Nullable<int> code_service { get; set; }
        public string phone { get; set; }
        public string password { get; set; }
        public Nullable<System.DateTime> release_date { get; set; }
        public Nullable<System.DateTime> validityc { get; set; }
        public Nullable<System.DateTime> validityw { get; set; }
        public Nullable<int> code_weapons_license { get; set; }
        public Nullable<int> code_car_license { get; set; }
        public string description_service { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<availability_volunteer> availability_volunteer { get; set; }
        public virtual car_license car_license { get; set; }
        public virtual city city { get; set; }
        public virtual gender gender { get; set; }
        public virtual personal_status personal_status { get; set; }
        public virtual services services { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<training_volunteer> training_volunteer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<volunteer_domain> volunteer_domain { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<volunteer_language> volunteer_language { get; set; }
        public virtual weapons_license weapons_license { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<embedding> embedding { get; set; }
    }
}