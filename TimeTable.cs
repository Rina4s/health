//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace health
{
    using System;
    using System.Collections.Generic;
    
    public partial class TimeTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TimeTable()
        {
            this.ListTimeTableForWorker = new HashSet<ListTimeTableForWorker>();
        }
    
        public int id { get; set; }
        public System.DateTime date { get; set; }
        public System.TimeSpan time { get; set; }
        
         
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ListTimeTableForWorker> ListTimeTableForWorker { get; set; }
    }
}
