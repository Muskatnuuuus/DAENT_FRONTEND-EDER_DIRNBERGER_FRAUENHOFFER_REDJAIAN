namespace DAENT_FRONTEND.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("wawi.artikelgruppen")]
    public partial class artikelgruppen
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public artikelgruppen()
        {
            artikel = new HashSet<artikel>();
        }

        [Key]
       // public int artnr { get; set; }

        [StringLength(2)]
        public string artgr { get; set; }

        [Required]
        [StringLength(50)]
        public string grtext { get; set; }

     //   public bool aktuell { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<artikel> artikel { get; set; }
    }
}
