﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class IS_YchetSotrudnikovYpravleniePersonalomEntities : DbContext
    {

        private static IS_YchetSotrudnikovYpravleniePersonalomEntities _context;


        public IS_YchetSotrudnikovYpravleniePersonalomEntities()
            : base("name=IS_YchetSotrudnikovYpravleniePersonalomEntities")
        {
        }

        public static IS_YchetSotrudnikovYpravleniePersonalomEntities GetContext()
        {
            if (_context == null)
            {
                _context = new IS_YchetSotrudnikovYpravleniePersonalomEntities();
            }
            return _context;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Education> Education { get; set; }
        public virtual DbSet<Education_employe> Education_employe { get; set; }
        public virtual DbSet<Employe> Employe { get; set; }
        public virtual DbSet<Employe_Tasks> Employe_Tasks { get; set; }
        public virtual DbSet<History_tasks> History_tasks { get; set; }
        public virtual DbSet<LogTable> LogTable { get; set; }
        public virtual DbSet<Post> Post { get; set; }
        public virtual DbSet<Post_Employe> Post_Employe { get; set; }
        public virtual DbSet<Sallary> Sallary { get; set; }
        public virtual DbSet<Sick> Sick { get; set; }
        public virtual DbSet<Stake> Stake { get; set; }
        public virtual DbSet<Tasks> Tasks { get; set; }
        public virtual DbSet<Type_day> Type_day { get; set; }
        public virtual DbSet<Work_schedule> Work_schedule { get; set; }
        public virtual DbSet<Work_schedule_Employe> Work_schedule_Employe { get; set; }
    }
}