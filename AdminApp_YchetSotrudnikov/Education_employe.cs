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
    
    public partial class Education_employe
    {
        public int ID_Education_employe { get; set; }
        public int Education_ID { get; set; }
        public int Employe_ID { get; set; }
    
        public virtual Education Education { get; set; }
        public virtual Employe Employe { get; set; }
    }
}
