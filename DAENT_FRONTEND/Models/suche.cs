namespace DAENT_FRONTEND.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

  //  [Table("wawi.artikelgruppen")]
    public partial class suche
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public suche()
        {
           
        }

        [Key]
        public int suchnr { get; set; }

        [StringLength(20)]
        public string searchstring { get; set; }


    }
}
