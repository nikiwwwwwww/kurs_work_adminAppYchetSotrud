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
    
    public partial class History_tasks
    {
        public int ID_History_tasks { get; set; }
        public bool Сompleted { get; set; }
        public bool On_time { get; set; }
        public int Tasks_ID { get; set; }
    
        public virtual Tasks Tasks { get; set; }
    }
}