//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AdminApp_YchetSotrudnikov
{
    using System;
    using System.Collections.Generic;
    
    public partial class Employe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employe()
        {
            this.Education_employe = new HashSet<Education_employe>();
            this.Employe_Tasks = new HashSet<Employe_Tasks>();
            this.Post_Employe = new HashSet<Post_Employe>();
            this.Work_schedule_Employe = new HashSet<Work_schedule_Employe>();
        }
    
        public int ID_Employe { get; set; }
        public string SOLI { get; set; }
        public string Name { get; set; }
        public string Last_name { get; set; }
        public string Middle_name { get; set; }
        public System.DateTime Date_of_employment { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Phone_number { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Education_employe> Education_employe { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Employe_Tasks> Employe_Tasks { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Post_Employe> Post_Employe { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Work_schedule_Employe> Work_schedule_Employe { get; set; }
    }
}